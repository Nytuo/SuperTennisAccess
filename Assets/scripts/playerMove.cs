using System;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public bool isJumping = false;
    public float jumpForce;
    public Rigidbody2D rb;
    public bool canShoot;
    private GameObject ball;
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") *moveSpeed * Time.deltaTime;
        MovePlayer(horizontalMovement);

    }

    private void Update()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
        if (Input.GetButtonDown("Jump") && isJumping == false)
        
        {
            isJumping = true;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
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

    private void Shoot()
    {
        if (canShoot == true)
        {
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 300f));
        }
    }
}
