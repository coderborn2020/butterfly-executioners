using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMove : MonoBehaviour
{
    public float speed = 1f;
    public GameObject prefab;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    

    void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
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

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;

        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(speed * -Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f);
        Debug.Log(raycastHit2d);
        return raycastHit2d.collider != null;
    }
}
