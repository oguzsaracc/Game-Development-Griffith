using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcRandomMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float wanderRange = 5.0f;
    public LayerMask groundLayer;

    private Vector3 wanderTarget;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewWanderTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, wanderTarget) <= 0.2f)
        {
            SetNewWanderTarget();
        }

        agent.SetDestination(wanderTarget);
    }

    private void SetNewWanderTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRange;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRange, NavMesh.AllAreas))
        {
            wanderTarget = hit.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (groundLayer == (groundLayer | (1 << other.gameObject.layer)))
        {
            SetNewWanderTarget();
        }
    }
}
