using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3PlayerScript : MonoBehaviour
{
    Rigidbody2D myRigidyBody;
    public float maxSpeed;                  // Maximum speed the player can move.
    public float jumpPower;                 // How much the jump force to apply.
    public float accelerationSpeed;         // How fast the Rigidbody will accelerate to maxSpeed.
    // Additional settings for mid-air -----------------------------------------------------------------------
    public float inAirAccelerationSpeed;    // How fast the Rigidbody will accelerate to maxSpeed when NOT on the ground.
    public float inAirMaxSpeed;             // When the player is not on the ground, use this MaxSpeed.
    // Week 3 Work -------------------------------------------------------------------------------------------
    Animator anim;                          // Sets a variable called anim of type Animator.
    float currentSpeed;                     // This will be used to check for the horizontal velocity of RigidBody2D.
    float upSpeed;                          // This will be used to check for the vertical velocity of the RigidyBody2D.
    public Transform animatorTransform;
    public bool isGrounded;                 // To Check is the Player grounded.
    public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        myRigidyBody = GetComponent<Rigidbody2D>();   // Gets the Rigidybody 2D component and assigns it to the variable myRigidyBody.
        anim = GetComponentInChildren<Animator>();    // GetComponent Animator and assign it to anim. 
        dust.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move Start ------------------------------------------------------------------------------------
        currentSpeed = myRigidyBody.velocity.x;     // Sets currentSpeed variable to the current horizontal velocity of the rigidbody.
        float move = Input.GetAxis("Horizontal");   // Checks input axis on the horizontal, so A, D or arrow left and right buttons. It will also work with controller.

        // This following if/else statement checks to see if the user pressed the right/left buttons, and tells the Animator if the right button has been placed.
        if (move < 0)
        {
            animatorTransform.localScale = new Vector3(-1, animatorTransform.localScale.y, animatorTransform.localScale.z); // To Flip GameObject.
            if (!dust.isPlaying) dust.Play();
        }
        else if (move > 0)
        {
            animatorTransform.localScale = new Vector3(1, animatorTransform.localScale.y, animatorTransform.localScale.z);
            if (!dust.isPlaying) dust.Play();
        }

        if (move == 0)
        {
            if (dust.isPlaying) dust.Stop();
        }

        if (Mathf.Abs(currentSpeed) < maxSpeed && isGrounded == true)
        {             // It will only add more force if maxSpeed is not yet reached, AND player is on the ground.
            myRigidyBody.AddForce(new Vector2(move * accelerationSpeed, 0));
        }

        if (Mathf.Abs(currentSpeed) < inAirMaxSpeed && isGrounded == false)
        {       // If player is in the air, reduce the amount of force added, since player is in air.
            myRigidyBody.AddForce(new Vector2(move * inAirAccelerationSpeed, 0));
        }

        anim.SetFloat("speed", (Mathf.Abs(currentSpeed + move)));
        // Move End ------------------------------------------------------------------------------------

        // Jump Start ----------------------------------------------------------------------------------
        upSpeed = myRigidyBody.velocity.y;          // Sets the e current vertical velocity of the rigidbody and set that float value to upSpeed.
        float moveUp = Input.GetAxis("Vertical");   // Checks input axis on the vertical, so W or arrow up button. It will also work with controller.

        if (Input.GetKey("space") && myRigidyBody.velocity.y < 0.1 && myRigidyBody.velocity.y > -0.1 && isGrounded == true || moveUp > 0.1 && myRigidyBody.velocity.y < 0.1 && myRigidyBody.velocity.y > -0.1 && isGrounded == true)
        {
            myRigidyBody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);  // If all the above conditions are correct, then jumps.
        }

        if (isGrounded == false) // ** WHEN PLAYER IN AIR DUST WILL STOP. 
        {
            if (dust.isPlaying) dust.Stop(); // ** Added that to stop dust in mid-air.
        } 

        anim.SetFloat("verticalSpeed", (upSpeed + moveUp)); // Tells the animator what the current vertical speed of the player is, in the form of a float called verticalSpeed. if positive, is moving up, negative, is falling.
        // Jump End ------------------------------------------------------------------------------------
    }

    // Ground Check Start ------------------------------------------------------------------------------
    // Checks if player is on the ground, and sends a bool to the Animator called grounded that is true if the player is on the ground, false if not.
    private void OnTriggerStay2D(Collider2D collision) // It needs a trigger to work.
    {
        if (collision.gameObject.tag != "Player" && collision.isTrigger == false) // It will ignore any colliders marked player and any colliders that are Triggers.
        {
            isGrounded = true; // If a collider NOT marked player is detected, it marks the player as being on the ground (or a surface).
            anim.SetBool("grounded", true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.isTrigger == false)
        {
            isGrounded = false;
            anim.SetBool("grounded", false);
        }

    }
    // Ground Check End --------------------------------------------------------------------------------
}