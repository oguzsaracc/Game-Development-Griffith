using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public bool PlayerRunDetected;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRunDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //agent.destination = goal[20].position;
            PlayerRunDetected = true;
            Debug.Log("OnTrigger activated by Player");
        }
        else
        {
            PlayerRunDetected = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRunDetected = false;
            Debug.Log("OnTrigger de-activated by Player");
        }
        else
        {
            PlayerRunDetected = false;
        }
    }
}
