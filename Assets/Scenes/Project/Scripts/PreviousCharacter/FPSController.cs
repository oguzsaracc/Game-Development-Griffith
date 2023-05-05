using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public AudioSource audioSource;
    public AudioClip walkingSound;
    public AudioClip runningSound;
    public AudioClip jumpingSound;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        bool isMoving = (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);

        // Check if the player is running
        bool isRunning = (Input.GetKey(KeyCode.LeftShift) && isMoving);

        // Set the appropriate audio clip and volume
        if (isMoving)
        {
            if (isRunning)
            {
                audioSource.clip = runningSound;
            }
            else
            {
                audioSource.clip = walkingSound;
            }

            // Play the sound if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop the audio when the player is not moving
            audioSource.Stop();
        }
        // Check if the player is moving
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            // Check if the audio is not already playing
            if (!audioSource.isPlaying)
            {
                // Set the audio clip and play the sound
                audioSource.clip = walkingSound;
                audioSource.Play();
            }
        }
        else
        {
            // Stop the audio when the player is not moving
            audioSource.Stop();
        }

        #region Handles Cursor Lock/Unlock

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            audioSource.clip = jumpingSound;
            audioSource.Play();
        }

        #endregion

        #region Handles Movement

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion

        #region Handles Animations

        Animator animator = GetComponent<Animator>();

        // Idle animation
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && canMove)
        {
            animator.Play("Idle");
        }

        // Walk animation
        if (Input.GetAxis("Vertical") != 0 && canMove && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("Walk");
        }

        // Run animation
        if (Input.GetAxis("Vertical") != 0 && canMove && Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("Run");
        }

        // Walk animation with A or D key
        if (Input.GetAxis("Horizontal") != 0 && canMove && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("Walk");
        }

        // Run animation with A or D key
        if (Input.GetAxis("Horizontal") != 0 && canMove && Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("Run");
        }

        // Walk animation with W and A or W and D keys
        if ((Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0) && canMove && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("Walk");
        }

        // Run animation with W and A or W and D keys
        if ((Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0) && canMove && Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("Run");
        }

        // Walk animation with S key
        if (Input.GetAxis("Vertical") < 0 && canMove && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("Walk");
        }

        // Run animation with S key
        if (Input.GetAxis("Vertical") < 0 && canMove && Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play("Run");
        }

        #endregion


    }
}