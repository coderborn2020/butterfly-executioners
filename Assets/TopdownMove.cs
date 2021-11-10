using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownMove : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public float bulletSpeed;

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
            Shoot();
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

    private void Shoot()
    {
        // spawn bullet
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 bulletTrajectory = (mouseLocation - transform.position).normalized;
        bulletTrajectory.z = 0;
        bullet.GetComponent<BulletScript>().speed = bulletTrajectory*bulletSpeed;
    }
}
