using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Speed;
    [SerializeField] private float SprintMultiplier = 1f;
    [SerializeField] private float moveSpeed;
    public bool crawl;

    [SerializeField] private float MouseSensitivityX = 1;
    [SerializeField] private float MouseSensitivityY = 1;

    Vector2 look;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Transform camTransformoffset;
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

        //Actual attempt at sprinting
        if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
        {
            SprintMultiplier = 1.5f;
        }
        else
        {
            SprintMultiplier = 1f;
        }
        bool isGrounded = Physics.Raycast(playerTransform.position, Vector3.down, playerTransform.localScale.y / 2 + 0.1f);
        Debug.Log(isGrounded);

    }

    void FixedUpdate()
    {
        // Movement input (old input system)
        float x = UnityEngine.Input.GetAxis("Horizontal");
        float z = UnityEngine.Input.GetAxis("Vertical");

        Vector3 move =
            playerTransform.forward * z * SprintMultiplier +
            playerTransform.right * x * SprintMultiplier;
        move *= Speed;

        Vector3 velocity = rb.linearVelocity;
        Vector3 movevelocity = new Vector3(move.x, velocity.y, move.z);
        rb.linearVelocity = movevelocity;
    }

    void OnCollisionStay()
    {
        
    }

}
