using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jerryMoveScrupt : MonoBehaviour
{
    Transform player;
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Vector2 movement;

    public float minDistance = 5f;
    public float range;
    private EnemyBaseScript baseScript;

    // Start is called before the first frame update
    void Start()
    {
        minDistance += Random.Range(-2f, 2f); // make the jerries range a bit random although in a range from 3 to 7 by default
        player = GameObject.Find("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        baseScript = GetComponent<EnemyBaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (baseScript.SeesPlayer)
        {
            // behavior if Jerry knows where player is
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // oculd rotate Jerry but it looks kind of weird so we don't
            //rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            range = Vector2.Distance(transform.position, player.position);
            float step = -moveSpeed * Time.deltaTime;

            if (range < minDistance) 
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, step);
            }
        }
    }

    private void FixedUpdate() {
        moveJerry(movement);
    }
    void moveJerry(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

        if (Mathf.Abs(range - minDistance) < 0.5)
        {
            // if close to the ring around the player, move to the side
            Vector2 diff = (transform.position - player.position).normalized;
            Vector2 rotate90 = new Vector2(-diff.y, diff.x); // https://stackoverflow.com/questions/4780119/2d-euclidean-vector-rotations

            rb.MovePosition(rb.position + rotate90*moveSpeed*Time.deltaTime); // magic numberdont care
        }
    }
}
