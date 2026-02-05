using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Speed;
    
    [SerializeField] private float MouseSensitivityX = 1;
    [SerializeField] private float MouseSensitivityY = 1;

    Vector2 look;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Transform playerTransform;

    //Old input system stuff
    private float horizontal;
    private float vertical;
    Vector3 moveDirections;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Jump input (old input system)
        if (UnityEngine.Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        look.x += UnityEngine.Input.GetAxis("Mouse X") * MouseSensitivityX;
        look.y += UnityEngine.Input.GetAxis("Mouse Y") * MouseSensitivityY;

        look.y = Mathf.Clamp(look.y, -89f, 89f);
        playerTransform.localRotation = Quaternion.Euler(0, look.x, 0);
        camTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
    }

    void FixedUpdate()
    {
        // Movement input (old input system)
        float x = UnityEngine.Input.GetAxis("Horizontal");
        float z = UnityEngine.Input.GetAxis("Vertical");

        // Below is old shitty movement, remove the comments for peak shitness
        /*Vector3 move = new Vector3(x, 0f, z) * Speed;
        Vector3 velocity = rb.linearVelocity;
        velocity.x = move.x;
        velocity.z = move.z;

        Vector3 worldMove = transform.TransformVector(move.x, 0, move.z);

        rb.linearVelocity = velocity worldMove * Speed; */

        Vector3 move =
            playerTransform.forward * z +
            playerTransform.right * x;
        move *= Speed;

        Vector3 velocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(move.x, velocity.y, move.z);
    }
}
