using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMove : MonoBehaviour
{

    public float speed = 1f;
    public GameObject prefab;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask platformLayerMask;
    

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

        

        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;

        }

        HandleMovement();
        

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, platformLayerMask);
        //output to console:
        Debug.Log(raycastHit2d);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement()
    {
        float moveSpeed = 5f;
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }
}
