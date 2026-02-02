using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Speed;

    //Old input system stuff
    private float horizontal;
    private float vertical;
    Vector3 moveDirections;

    void Update()
    {
        // Jump input (old input system)
        if (UnityEngine.Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Movement input (old input system)
        float x = UnityEngine.Input.GetAxis("Horizontal");
        float z = UnityEngine.Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z) * Speed;
        Vector3 velocity = rb.linearVelocity;
        velocity.x = move.x;
        velocity.z = move.z;
        rb.linearVelocity = velocity;
    }
}
