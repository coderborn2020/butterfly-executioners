using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bobMoveScrupt : MonoBehaviour
{
    Transform player;
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    private EnemyBaseScript baseScript;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        baseScript = GetComponent<EnemyBaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (baseScript.SeesPlayer)
        {
            // behavior if Bob knows where player is
            Vector3 direction = player.position - transform.position;
            Debug.Log(direction);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle+90f;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate() {
        moveBob(movement);
    }
    void moveBob(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
