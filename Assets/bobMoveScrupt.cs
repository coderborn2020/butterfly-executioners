using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobMoveScrupt : MonoBehaviour
{
    public GameObject player;

    public Rigidbody2D rigidbody2D;
    public Vector2 bobSpeed = new Vector2(1, 1);

    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D.velocity = bobSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            // change bob speed
            rigidbody2D.velocity = new Vector2(Random.Range(-1f*5, 1f*5), Random.Range(-1f*5, 1f*5));
        }
    }
}
