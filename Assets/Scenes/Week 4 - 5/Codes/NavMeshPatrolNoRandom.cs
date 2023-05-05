using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrolNoRandom : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform[] goal;
    public GameObject player;
    public float detectRadius;

    public bool playerDetected;

    private int currentGoalIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal[currentGoalIndex].position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is in range
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= detectRadius)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }

        // once the agent reaches the goal, it will go to the next goal
        if (agent.remainingDistance < 0.5f && playerDetected == false)
        {
            currentGoalIndex = (currentGoalIndex + 1) % goal.Length;
            agent.destination = goal[currentGoalIndex].position;
        }
        // if the player is detected, the agent will go to the player's position
        else if (playerDetected == true)
        {
            agent.destination = player.transform.position;
        }
    }
}