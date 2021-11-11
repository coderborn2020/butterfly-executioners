using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jerryMoveScrupt : MonoBehaviour
{
    //public GameObject Player;
    Transform player;
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Vector2 movement;

    public float minDistance = 3f;
    public float range;

    //public Vector2 bobSpeed = new Vector2(1, 1);
    

    // private float nextActionTime = 0.0f;
    // public float period = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
        //rigidbody2D.velocity = bobSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 may be a problem, could have to be Vector3
        Vector3 direction = player.position - transform.position;
        Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        range = Vector2.Distance(transform.position, player.position);
        float step = -moveSpeed * Time.deltaTime;

        if (range < minDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        }
        // if (Time.time > nextActionTime ) {
        //     nextActionTime += period;
        //     // change bob speed
        //     rigidbody2D.velocity = new Vector2(Random.Range(-1f*5, 1f*5), Random.Range(-1f*5, 1f*5));
        // }
    }

    private void FixedUpdate() {
        moveBob(movement);
    }
    void moveBob(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
