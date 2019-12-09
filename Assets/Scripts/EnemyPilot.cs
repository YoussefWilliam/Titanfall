using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyPilot : MonoBehaviour
{
    private float targetOffset;
    public NavMeshAgent agent;
    public Transform target;
    private Animator anim;
    private readonly float minAttackDistance = 10f;
    private readonly float retreadDistance = 2f ;
    public AudioManager audioManager;
    private readonly float enemyStartHealth = 100;
    private readonly float titanStartHealth = 400;
    private float health;
    private bool isDead = false;
    private bool isHit = false;
    public GameObject canvas;
    public RifleGun rifleGun;
    public SniperGun sniperGun;
    public ShotGun shotGun;
    public GameObject player;


    [Header("Unity Stuff")]
    public Image healthbar;

   void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent.gameObject.CompareTag("PilotEnemyRifle") || agent.gameObject.CompareTag("PilotEnemySnipper") || agent.gameObject.CompareTag("PilotEnemyShotgun"))
        {
            health = enemyStartHealth;
        }
        else if (agent.gameObject.CompareTag("titanEnemy"))
        {
            health = titanStartHealth;
        }
        targetOffset = 0.5f;

    }

    public void TakeDamage(float gunDamage)
    {
        health -= gunDamage;
        HitTheEnemy();
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x + targetOffset, 0, direction.z));
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*10f);
        transform.rotation = lookRotation;
    }
    void agentStop()
    {
        anim.SetBool("Move", false);
        anim.SetBool("Done", true);
        agent.speed = 0.1f;
    }
    void agentMove()
    {
        agent.isStopped = true;
        agent.ResetPath();
        anim.SetBool("Move", true);
        anim.SetBool("Done", false);
        anim.SetBool("Shoot", false);

    }
    void agentAttack()
    {
        FaceTarget();

        if (!isDead)
        {
            if (agent.gameObject.CompareTag("PilotEnemyRifle"))
            {
                rifleGun.Shoot();
            }
            if (agent.gameObject.CompareTag("PilotEnemySnipper"))
            {
                sniperGun.Shoot();
            }
            if (agent.gameObject.CompareTag("PilotEnemyShotgun"))
            {
                shotGun.Shoot();
            }
            agent.isStopped = true;
            agent.ResetPath();
            anim.SetBool("Move", false);
            anim.SetBool("Done", false);
            anim.SetBool("Shoot", true);
            if (isHit)
            {
                anim.SetBool("Hit", true);
            }
        }   
    }
    void hitEnemy()
    {
        if (!isDead && isHit)
        {
            agent.isStopped = true;
            agent.ResetPath();
            anim.SetBool("Move", false);
            anim.SetBool("Done", false);
            anim.SetBool("Shoot", false);
            anim.SetBool("Hit", true);
            Invoke("notHit", 0.5f);
        }
    }
    void notHit()
    {
        anim.SetBool("Hit", false);
        isHit = false;
    }
    void destroyEnemy()
    {
        canvas.SetActive(false);
    }
    void HitTheEnemy()
    {
        if (!anim.GetBool("Hit") && !isHit)
        {
            isHit = true;
            hitEnemy();
            FaceTarget();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (agent.gameObject.CompareTag("PilotEnemyRifle") || agent.gameObject.CompareTag("PilotEnemySnipper") || agent.gameObject.CompareTag("PilotEnemyShotgun"))
        {
            healthbar.fillAmount = health / enemyStartHealth;
        }
        else if (agent.gameObject.CompareTag("titanEnemy"))
        {
            healthbar.fillAmount = health / titanStartHealth;
        }


        float distance = Vector3.Distance(agent.transform.position, target.position);

        if (distance < minAttackDistance && distance > retreadDistance)
        {
            FaceTarget();
            agent.SetDestination(target.position);
            if (!(anim.GetBool("Move")) && !isDead)
            {
                agentMove();
            }
        }
        if (distance < retreadDistance && (anim.GetBool("Move")) && !isDead)
        {
            agentStop();
            InvokeRepeating("agentAttack", 0f,3f);
        }

        if(health <= 0 && !isDead)
        {
            anim.SetBool("Move", false);
            anim.SetBool("Done", false);
            anim.SetBool("Shoot", false);
            anim.SetTrigger("Die");
            isDead = true;
            agent.isStopped = true;
            player.GetComponent<Player>().CoreUp();
            Invoke("destroyEnemy", 5f);
        }
    }
}
