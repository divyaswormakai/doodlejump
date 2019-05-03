using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    SpriteRenderer sprt;
    float movement = 0f;
    public float movementSpeed = 3f;
    bool facingRight;
    float prevPlatformPos = 0f;

    public GameObject levelGenerator;
    void Start()
    {
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        movement = horizontalInput * movementSpeed;
        FlipSprite(horizontalInput);
        //torunn
        if(rb2d.velocity.y == 0)
        {
            print("ASDF");
        }

        //take highest height from two jumps compare them and then if differ then call levelgenerator
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = movement;
        rb2d.velocity = velocity;
    }

    void FlipSprite(float inp)
    {
       if(inp>0 && !facingRight)
        {
            facingRight = !facingRight;
            sprt.flipX = false;
        }
       if(inp < 0 && facingRight)
        {
            facingRight = !facingRight;
            sprt.flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float currentPlatformPos = collision.transform.position.y;
        if (currentPlatformPos > prevPlatformPos)
        {
            levelGenerator.GetComponent<LevelGenerator>().CreateNextPlatforms(currentPlatformPos);
            prevPlatformPos =currentPlatformPos;
        }
    }
}
