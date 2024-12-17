using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    public float speed = 0;
    public float speed2 = 0;
    Rigidbody2D rb;
    Vector2 dir;
    public Transform target;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        dir = target.transform.position - this.transform.position;
        rb.velocity = dir.normalized * speed;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            collision.rigidbody.AddForce(dir * speed2);

        }
    }
}
