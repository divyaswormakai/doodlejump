using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerBox, bar;
    public float velocity;
    Rigidbody2D rb;
    void Start()
    {
        rb = playerBox.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * 5, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * 5, ForceMode2D.Force);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name=="bar")
        {
            rb.AddForce(Vector2.up*velocity,ForceMode2D.Impulse);
        }

    }
}
