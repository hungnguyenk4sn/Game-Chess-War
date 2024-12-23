using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed = 0;
    public float speed2 = 0;
    Rigidbody2D rb;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        rb.velocity = (Vector2.left * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bluebird"))
        {
            collision.rigidbody.AddForce(Vector2.left * speed2);
            Debug.Log(collision.gameObject.tag);
        }
    }
}
