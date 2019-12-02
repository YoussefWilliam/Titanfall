using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyPilot : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    private Animator anim;
    float minAttackDistance = 50f;
    float retreadDistance = 15f;
    public AudioManager audioManager;
    public float enemyStartHealth = 100;
    private float health;
    private bool isDead = false;
    private bool isHit = false;

    [Header("Unity Stuff")]
    public Image healthbar;

   void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        health = enemyStartHealth;

    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*10f);
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
    }
    void agentAttack()
    {
        if (!isDead)
        {
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
            Invoke("notHit", 2f);
        }
    }
    void playShoot()
    {
        audioManager.Play("Coins");
    }
    void notHit()
    {
        anim.SetBool("Hit", false);
        isHit = false;
    }
    void decreaseHealth()
    {
        health-= 1;
    }
    void destroyEnemy()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = health / enemyStartHealth;

        float distance = Vector3.Distance(agent.transform.position, target.position);

        if (distance < minAttackDistance && distance > retreadDistance)
        {
            agent.SetDestination(target.position);
            if (!(anim.GetBool("Move")) && !isDead)
            {
                agentMove();
            }
        }
        if (distance < retreadDistance && (anim.GetBool("Move")) && !isDead)
        {
            agentStop();
            FaceTarget();
            InvokeRepeating("agentAttack", 0f,3f);
        }

        // Test decrease health bars
        if (Input.GetKey(KeyCode.Space))
        {
            decreaseHealth();
        }
        if(health <= 0 && !isDead)
        {
            anim.SetBool("Move", false);
            anim.SetBool("Done", false);
            anim.SetBool("Shoot", false);
            anim.SetTrigger("Die");
            isDead = true;
            agent.isStopped = true;
            Invoke("destroyEnemy", 5f);
        }

        if (Input.GetKey(KeyCode.H) && !anim.GetBool("Hit") && !isHit)
        {
            isHit = true;
            hitEnemy();
            FaceTarget();
        }

    }
}
