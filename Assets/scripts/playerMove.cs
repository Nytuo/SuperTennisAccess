using System;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public bool isJumping = false;
    public float jumpForce;
    public Rigidbody2D rb;
    private Vector3 _velocity = Vector3.zero;
    public Collider2D cc;
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") *moveSpeed * Time.deltaTime;
        MovePlayer(horizontalMovement);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isJumping == false)
        
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
    }

    private void MovePlayer(float horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref _velocity, 0.05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }
}
