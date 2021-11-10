using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownMove : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector2(0, -speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += new Vector2(0, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += new Vector2(-speed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += new Vector2(speed, 0);
        }

    }
}
