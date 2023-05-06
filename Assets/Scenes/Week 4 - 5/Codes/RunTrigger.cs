using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject run;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        run = GameObject.FindGameObjectWithTag("Run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
