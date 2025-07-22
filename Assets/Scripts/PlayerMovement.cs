using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 12f;
    public float dashForce = 15f;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GroundCheck();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        moveDirection = new Vector3(h, 0f, v).normalized;

        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            rb.AddForce(moveDirection * dashForce, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (moveDirection.magnitude >= 0.1f)
            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
    }
}
