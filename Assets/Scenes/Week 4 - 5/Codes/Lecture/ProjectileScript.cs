using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileLife;
    public int projectileType;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ProjectileCountdown");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log("test");
            print("Enemy hit");
            switch (projectileType)
            {
                case 1:
                    col.gameObject.GetComponent<NavMeshAgentEnemy>().StartCoroutine("Stunned"); ;
                    break;
                default:

                    break;
            }
            Destroy(gameObject);
        }


    }

    IEnumerator ProjectileCountdown()
    {
        yield return new WaitForSeconds(projectileLife);
        Destroy(gameObject);
    }
}