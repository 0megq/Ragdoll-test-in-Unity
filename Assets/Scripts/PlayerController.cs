using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    private bool isGrounded;
    public LayerMask ground;
    public Transform groundCheck;
    public float groundRadius;
    public float jumpForce;
    private bool jump;

    public Transform cameraTransform;

    void Awake()
    {
        
    }


    void Update()
    {
        jump = 0<Input.GetAxis("Vertical") && Input.GetButtonDown("Vertical");
        if (jump && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);

        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, rb.velocity.y);


        //Camera follows player
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y, -10);

        //Keeps groundcheck at same relative position to ball
        groundCheck.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
    }
}
