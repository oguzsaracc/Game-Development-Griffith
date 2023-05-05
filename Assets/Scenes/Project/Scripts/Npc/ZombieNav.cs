using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNav : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;
    public float followDistance; // distance at which zombie starts following player
    public float maxSpeed; // maximum speed of the zombie
    public float acceleration; // acceleration of the zombie

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        // set the maximum speed and acceleration of the zombie
        agent.speed = maxSpeed;
        agent.acceleration = acceleration;
    }

    void Update()
    {
        // set the zombie's destination to the player's position if the player is within followDistance
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= followDistance)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}