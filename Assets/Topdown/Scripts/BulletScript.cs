using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed*Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Walls") || other.gameObject.name == "WallsNoCam" || other.gameObject.name == "Platforms" ||
            (this.CompareTag("EnemyBullet") && other.gameObject.CompareTag("Player")) ||
            (this.CompareTag("PlrBullet") && other.gameObject.CompareTag("Enemy"))
        )
        {
            Destroy(gameObject);
        }
    }
}
