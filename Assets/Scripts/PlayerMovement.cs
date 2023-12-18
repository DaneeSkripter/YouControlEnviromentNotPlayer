using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float walkSpeed;
    public float sprintSpeed;
    private float speed;
    public float jumpHeight;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    private bool isGrounded() => Physics.CheckSphere(groundCheck.transform.position, 0.4f, groundLayer);
    
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
            }
            else
            {
                speed = walkSpeed;
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded())
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            var direction = Vector3.zero;

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            direction = transform.right * x + transform.forward * z;

            rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
        }
    }

}
