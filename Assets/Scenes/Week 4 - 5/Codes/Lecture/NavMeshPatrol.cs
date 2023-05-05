using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrol : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform[] goal;
    public GameObject player;
    public GameObject run;
    public float detectRadius;
    public bool playerDetected;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal[0].position;
        player = GameObject.FindGameObjectWithTag("Player");
        run = GameObject.FindGameObjectWithTag("Run");
    }

    // Update is called once per frame.
    void Update()
    {
        // Checks if player is in range.
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectRadius)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }

        // Once the agent reaches the goal, it will go to the next goal.
        if (agent.remainingDistance < 0.5f && playerDetected == false)
        {
            agent.destination = goal[Random.Range(0, goal.Length)].position;
        }

        // Once they alerted, they will go to the goal[20], which is the patrol point near to the exit.
        else if (playerDetected == true)
        {
            agent.destination = player.transform.position;
        }

        if (run.GetComponent<PlayerDetect>().PlayerRunDetected == true)
        {
            agent.destination = goal[20].position;
        }
    }
}