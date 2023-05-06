using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    void onTriggerEnter(Collision collision)
    {
        if( collision.gameObject.tag == "AddScore")
        {
            Debug.Log("Collided with: " + collision);
        }

    }

    void onTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "AddScore")
        {
            Debug.Log("Triggered with: " + collider);
        }

    }

    //onCollisionExit & Enter

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "AddScore")
        {
            Debug.Log("Collided with: " + other);
            print("+1");
        }
    }
}
