using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Speed;
    [SerializeField] private float moveSpeed;
    public bool crawl;

    [SerializeField] private float MouseSensitivityX = 1;
    [SerializeField] private float MouseSensitivityY = 1;

    Vector2 look;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Transform playerTransform;
<<<<<<< HEAD
=======

    //Old input system stuff
    private float horizontal;
    private float vertical;
    Vector3 moveDirections;
>>>>>>> parent of 27d3820 (idk)

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

        Vector3 move =
            playerTransform.forward * z +
            playerTransform.right * x;
        move *= Speed;

        Vector3 velocity = rb.linearVelocity;
        Vector3 movevelocity = new Vector3(move.x, 0, move.z);
        rb.linearVelocity = movevelocity;
    }

}
