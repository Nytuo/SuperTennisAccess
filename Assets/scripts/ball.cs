using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed;
    Vector2 direction;

    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }
        else if (col.gameObject.CompareTag("WallX"))
        {
            direction.x = -direction.x;
        }
        else if (col.gameObject.CompareTag("player"))
        {
            direction.x = -direction.x;
            if (Input.GetButton("Fire1"))
            {
                direction.y = -direction.y;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}