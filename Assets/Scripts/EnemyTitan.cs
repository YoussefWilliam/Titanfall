using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyTitan : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    private Animator anim;
    private float titanStartHealth = 400;
    float minAttackDistance = 50f;
    float retreadDistance = 15f;
    public AudioManager audioManager;
    private float health;


    [Header("Unity Stuff")]
    public Image healthbar;
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        health = titanStartHealth;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
