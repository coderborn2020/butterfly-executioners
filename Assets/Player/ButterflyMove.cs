using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMove : MonoBehaviour
{

    public float speed = 1f;
    private int ctr = 0;
    public GameObject bulletPrefab;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    public float shootPeriod = 2f;
    public float bulletSpeed;
    private bool readyToShoot = false;
    private float nextShootableTime = 0.0f;

    [HideInInspector]
    public bool isFacingleft;
    [HideInInspector]
    public bool isFacingRight;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool isJumping;

    public bool spawnFacingLeft;
    [SerializeField] private LayerMask platformLayerMask;
    private Vector2 facingLeft;
    private Vector2 facingRight;



    void Start()
    {
        Initialization();
    }

    protected virtual void Initialization()
    {
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        if (spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingleft = true;
        }
        facingRight = new Vector2(+transform.localScale.x, transform.localScale.y);

    }

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }


    protected virtual void Flip()
    {
        if (isFacingleft)
        {
            transform.localScale = facingLeft;
        }
        if (!isFacingleft)
        {
            transform.localScale = facingRight;
        }
    }

    // Update is called once per frame
    private void Update()
    {

        // make bullet
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            // spawn bullet
        //    var bullet = Instantiate(prefab, transform.position, Quaternion.identity);
        //    Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector3 bulletTrajectory = (mouseLocation - transform.position).normalized;
        //    bulletTrajectory.z = 0;
        //    bullet.GetComponent<BulletScript>().speed = bulletTrajectory;
        //}


            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                float jumpVelocity = 5f;
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
            }
        


        if (!IsGrounded())
        {
            ctr++;
        }
        else ctr = 0;


        HandleMovement();

        if (Input.GetMouseButton(0)) // left click
        {
            // make bullet
            if (readyToShoot) Shoot();
        }

        if (Time.time > nextShootableTime)
        {
            readyToShoot = true;
        }
    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        //output to console:
        return raycastHit2d.collider != null;
    }


    private void HandleMovement()
    {
        float moveSpeed = 5f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            isFacingleft = true;
            isFacingRight = false;
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            Flip();
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                isFacingRight = true;
                isFacingleft = false;
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                Flip();
            }
            else
            {
                //no keys being pressed
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }

    private void Shoot()
    {
        // spawn bullet
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 bulletTrajectory = (mouseLocation - transform.position);
        bulletTrajectory.z = 0;
        bullet.GetComponent<BulletScript>().speed = bulletTrajectory.normalized * bulletSpeed;
        nextShootableTime = Time.time + shootPeriod;
        readyToShoot = false;
    }

}
