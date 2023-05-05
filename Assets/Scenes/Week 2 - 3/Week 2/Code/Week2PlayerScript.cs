using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxSpeed;
    public float acceleration;
    public float jumpForce;
    public bool isGrounded; // To Check is the Player grounded
    public LayerMask groundLayers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets the Rigidybody 2D component and assigns it to the variable rb
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // get the horizontal axis value

        // isGrounded
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.10f, transform.position.y - 0.10f),
            new Vector2(transform.position.x + 0.10f, transform.position.y - 0.46f), groundLayers);

        // if the horizontal axis values is greater than0, then the player is moving right
        rb.AddForce(new Vector2(acceleration * horizontal, 0));

        // if spacebar is pressed, then the player jumps
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Vertical") > 0 && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }

    // Draw the OverlapArea
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.455f),
            new Vector2(1, 0.01f));
    }
}
