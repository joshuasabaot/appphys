using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 6f;
    public float accelerationSpeed = 15f;
    public float jumpForce =6f;

    InputAction _move;
    Rigidbody rb;
    Vector3 targetDirection;
    LayerMask groundLayer;
    bool isGrounded = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        var input = _move.ReadValue<Vector2>();
        targetDirection = new Vector3(input.x, 0, input.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        MoveBody();
    }

    private void Jump()
    {
        rb.linearVelocity += new Vector3(0, jumpForce, 0);
        isGrounded = false;
    }

    private void MoveBody()
    {
        var direction = targetDirection * maxSpeed;
        var velocityChange = direction - rb.linearVelocity;
        velocityChange.y = 0;
        rb.AddForce(velocityChange*accelerationSpeed, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
