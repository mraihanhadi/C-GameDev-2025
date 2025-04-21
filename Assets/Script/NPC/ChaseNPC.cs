using UnityEngine;
using UnityEngine.AI;

public class ChaseNPC : MonoBehaviour
{
    public float patrolRadius = 20f;
    public Transform player;

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolTarget;

    public float detectionRadius = 30f;
    private Vector3 originalPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //SetNewPatrolTarget();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(patrolTarget);

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            navMeshAgent.SetDestination(player.position);
        }

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= detectionRadius)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

}
