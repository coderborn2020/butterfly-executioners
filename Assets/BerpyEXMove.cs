using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerpyEXMove : MonoBehaviour
{

    List<Vector2> locations = new List<Vector2>() {
        new Vector2(-31.5f, -25.5f),
        new Vector2(-17.5f, -25.5f),
        new Vector2(-31.5f, -39.5f),
        new Vector2(-17.5f, -39.5f),
        new Vector2(-24.5f, -32.5f)
    };
    public float movePeriod = 2f;
    private float nextActionTime = 0.0f;

    public Rigidbody2D rb;
    public float moveSpeed = 6f;

    private Vector2 target = new Vector2(-24.5f, -32.5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextActionTime ) {
            nextActionTime = Time.time + movePeriod;
            // execute block of code here
            target = locations[Random.Range(0, 5)];
        }
    }

    private void FixedUpdate() {
        //rb.MovePosition(transform.position+(transform.position - (Vector3)target).normalized*moveSpeed);
            Vector3 direction = (Vector3)target - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            float step = -moveSpeed * Time.deltaTime;
            rb.MovePosition((Vector2)transform.position + ((Vector2)direction * moveSpeed * Time.deltaTime));
    }
}
