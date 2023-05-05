using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    float jumpForce;

    public GameStats gameStats;
    // Start is called before the first frame update
    void Start()
    {
        print("helloworld");
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        jumpForce = gameStats.jumpForce;

    }

    // Update is called once per frame
    void Update()
    {
        //when space button is pressed add force in the up direction
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);


        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("AddScore"))
        {
            //find GameStats script and run score function
            gameStats.AddScore(1);
            Debug.Log("Finish: " + other.gameObject.name);
        }
    }
}