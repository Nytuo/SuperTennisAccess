using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed;
    private Vector2 direction;

    private Rigidbody2D rb;

    Vector3 lastVelocity;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("player");
        /*direction = Vector2.one.normalized;*/
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized,col.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            _player.GetComponentInChildren<playerMove>().canShoot = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            _player.GetComponentInChildren<playerMove>().canShoot = false;
        }
    }
}