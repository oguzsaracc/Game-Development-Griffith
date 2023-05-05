using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentEnemy : MonoBehaviour
{
    public Transform goal;
    public float stunnedTime;
    public bool stunned;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (stunned != true)
        {
            agent.destination = goal.position;
        }



    }

    IEnumerator Stunned()
    {
        print("Stunning");
        agent.destination = transform.position;
        stunned = true;
        yield return new WaitForSeconds(stunnedTime);
        stunned = false;
    }
}