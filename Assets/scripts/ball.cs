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
    private GameObject _player2;
    private Vector3 _ballPosition;

    private GameObject _AI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("player");
        _player2 = GameObject.FindGameObjectWithTag("player2");

        /*direction = Vector2.one.normalized;*/
        _ballPosition = transform.position;
        _AI = GameObject.FindGameObjectWithTag("AI");
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
        if (col.gameObject.CompareTag("Wall"))
        {
            Debug.Log("PLayer 1 -1");
            _player.GetComponentInChildren<playerMove>().ResetPositions();
            try
            {
                _AI.GetComponentInChildren<AI>().ResetPositions();
            }
            catch (Exception e)
            {}
            try
            {
                _player2.GetComponentInChildren<playerMove>().ResetPositions();
            }
            catch (Exception e)
            {}
            transform.position = _ballPosition;
            rb.velocity = Vector3.zero;
        }
        else if (col.gameObject.CompareTag("Wall2"))
        {
            Debug.Log("PLayer 2 -1");
            _player.GetComponentInChildren<playerMove>().ResetPositions();
            try
            {
                _AI.GetComponentInChildren<AI>().ResetPositions();
            }
            catch (Exception e)
            {}
            try
            {
                _player2.GetComponentInChildren<playerMove>().ResetPositions();
            }
            catch (Exception e)
            {}


            transform.position = _ballPosition;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            _player.GetComponentInChildren<playerMove>().canShoot = true;
        }

        if (col.gameObject.CompareTag("player2"))
        {
            _player2.GetComponentInChildren<playerMove>().canShoot = true;
        }
        if (col.gameObject.CompareTag("AI"))
        {
            _AI.GetComponentInChildren<AI>().canShootAI = true;
        }

        if (col.gameObject.CompareTag("AIJump"))
        {
            _AI.GetComponentInChildren<AI>().canJumpAI = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            _player.GetComponentInChildren<playerMove>().canShoot = false;
        }
        if (col.gameObject.CompareTag("player2"))
        {
            _player2.GetComponentInChildren<playerMove>().canShoot = false;
        }
        if (col.gameObject.CompareTag("AI"))
        {
            _AI.GetComponentInChildren<AI>().canShootAI = false;
        }

        if (col.gameObject.CompareTag("AIJump"))
        {
            _AI.GetComponentInChildren<AI>().canJumpAI = false;
        }
    }
}