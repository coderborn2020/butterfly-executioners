using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMove : MonoBehaviour
{
    public float speed = 1f;
    public GameObject prefab;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // make bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // spawn bullet
            var bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 bulletTrajectory = (mouseLocation - transform.position).normalized;
            bulletTrajectory.z = 0;
            bullet.GetComponent<BulletScript>().speed = bulletTrajectory;
        }

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
