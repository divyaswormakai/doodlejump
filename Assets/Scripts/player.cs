using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    float moveInput;
    float speed = 10f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }
}
