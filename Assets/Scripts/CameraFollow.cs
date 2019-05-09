using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // public float smoothSpeed = .3f;
    //private Vector3 currentVelocity;
    // Start is called before the first frame update

    Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(target.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
                Vector3 newPos = new Vector3(0, target.position.y + offset.y, 0);
                //this for late update
                // transform.position = Vector3.SmoothDamp(transform.position,newPos,ref currentVelocity,smoothSpeed*Time.deltaTime);
                transform.position = newPos;
        }
        
    }
}
