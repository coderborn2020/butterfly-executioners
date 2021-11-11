using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMove : MonoBehaviour
{

    public float speed = 1f;
    private int ctr = 0;
    public GameObject prefab;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    [SerializeField] private LayerMask platformLayerMask;



    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
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

        
        if (ctr == 0 || ctr >= 150)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                float jumpVelocity = 10f;
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
            }
        }


        if (!IsGrounded())
        {
            ctr++;
        }
        else ctr = 0;


        HandleMovement();

    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        //output to console:
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }


    private void HandleMovement()
    {
        float moveSpeed = 5f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                //no keys being pressed
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }

}
