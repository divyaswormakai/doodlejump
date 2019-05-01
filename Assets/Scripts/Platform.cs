using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D collider = collision.gameObject.GetComponent<Rigidbody2D>();
            if (collider != null)
            {
                Vector2 vel = collider.velocity;
                vel.y = speed;
                collider.velocity = vel;

            }
        }
    }
}
