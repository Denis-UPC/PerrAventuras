using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 6f;
    public float rotationSpeed = 10f;

    [Header("Salto")]
    public float jumpForce = 8f;
    public float groundRayLength = 0.6f;
    public LayerMask groundMask;

    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isDashing;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Verificar suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundRayLength, groundMask);
        Debug.Log("Is Grounded: " + isGrounded);

        // Movimiento libre
        if (!isDashing)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDir = new Vector3(moveX, 0, moveZ).normalized;

            if (moveDir.magnitude >= 0.1f)
            {
                // Rotar hacia la dirección de movimiento
                Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // Mover
                Vector3 velocity = moveDir * moveSpeed;
                rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
            }
            else
            {
                // Mantener la velocidad vertical si no hay input
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded && !isDashing)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        Vector3 dashDirection = transform.forward;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            rb.velocity = dashDirection * dashSpeed;
            yield return null;
        }

        isDashing = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRayLength);
    }
}
