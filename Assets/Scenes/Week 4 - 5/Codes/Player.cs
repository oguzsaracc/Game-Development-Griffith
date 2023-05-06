using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 5f;
    public Camera cam;          // The camera that the movement is relative to

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Convert keyboard input to world space
        Vector3 moveDir = cam.transform.right * horizontalInput + cam.transform.forward * verticalInput;
        moveDir.y = 0f;     // Disable movement in the y axis

        // Move player based on keyboard input
        transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;

        // Apply force in the keyboard move direction
        Vector3 keyboardMoveDir = new Vector3(horizontalInput, 0f, verticalInput);
        if (keyboardMoveDir.magnitude > 0f)
        {
            Vector3 keyboardMoveDirWorldSpace = cam.transform.TransformDirection(keyboardMoveDir);
            rb.AddForce(keyboardMoveDirWorldSpace.normalized * moveSpeed, ForceMode.Force);

            // Rotate player based on move direction
            Quaternion targetRotation = Quaternion.LookRotation(keyboardMoveDirWorldSpace, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}