using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AI : MonoBehaviour
{
    public float rangerDeflect, speed;

    public Transform deflect;

    private GameObject _ball;
    private Rigidbody2D _rb;
    public bool canShootAI, canJumpAI;
    private Vector3 _AIPos;

    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("ball");
        _rb = GetComponent<Rigidbody2D>();
        _AIPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (canShootAI == true)
        {
            Shoot();
        }
        if (canJumpAI == true)
        {
            Jump();
        }
    }


    public void Move()
    {
        if (Mathf.Abs(_ball.transform.position.x - transform.position.x) < rangerDeflect)
        {
            if (_ball.transform.position.x > transform.position.x)
            {
                _rb.velocity = new Vector2(Time.deltaTime * speed, _rb.velocity.y);
            }
            else
            {
                _rb.velocity = new Vector2(-Time.deltaTime * speed, _rb.velocity.y);
            }
        }
        else
        {
            if (transform.position.x > deflect.position.x)
            {
                _rb.velocity = new Vector2(-Time.deltaTime * speed, _rb.velocity.y);
            }
            else
            {
                _rb.velocity = new Vector2(0, _rb.velocity.y);

            }
        }
    }
    private void Shoot()
    {
        _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.8f, 0.8f));
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 10f);
    }
    public void ResetPositions()
    {
        transform.position = _AIPos;
    }
}