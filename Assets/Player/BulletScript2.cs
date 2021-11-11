using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{
    public Vector3 speed;
    public float fireRate = 0;
    public float Damage = 10f;
    public LayerMask notToHit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed*Time.deltaTime;
        
    }
}
