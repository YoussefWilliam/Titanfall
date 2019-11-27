using UnityEngine;
using UnityEngine.AI;

public class EnemyPilot : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    private Animator anim;
    bool isMoving = false;
    bool isStop = false;
    bool shouldStop = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);


    }

    // Update is called once per frame
    void Update()
    {
        float minAttackDistance = 25f;
        float distance = Vector3.Distance(agent.transform.position, target.position);
        Debug.Log(distance);
        agent.SetDestination(target.position);


        //if (distance < minAttackDistance)
        //{
        //  agent.SetDestination(target.position);
        if (!isMoving)
            {
                anim.SetTrigger("Move");
                isMoving = true;
            }
        //}

        if (agent.remainingDistance <= 9)
        {
            isStop = true;
        }
        if (isStop && !shouldStop)
        {
            isMoving = false;
            anim.SetTrigger("Done");
            shouldStop = true;
        }
        if (agent.remainingDistance <= 0)
        {
            agent.isStopped = true;
        }
   
    }
}
