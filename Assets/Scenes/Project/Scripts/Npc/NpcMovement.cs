using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform pointA;
    public Transform pointB;
    private Transform currentTarget;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pointA;
        direction = (currentTarget.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget.position) <= 0.2f)
        {
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
            direction = (currentTarget.position - transform.position).normalized;
        }

        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(currentTarget.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Restart the game if the player collides with a zombie
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
