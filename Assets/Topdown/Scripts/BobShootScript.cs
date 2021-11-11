using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobShootScript : MonoBehaviour
{
    // bullet that bob will shoot
    public GameObject bulletPrefab;

    public float shootBulletSpeed;
    public float shootBulletPeriod = 2f;
    private float nextActionTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += shootBulletPeriod;
            // execute block of code here
            ShootBullets();
        }
    }

    void ShootBullets()
    {
        List<GameObject> newBullets = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            newBullets.Add(Instantiate(bulletPrefab, transform.position, Quaternion.identity));
        }
        newBullets[0].GetComponent<BulletScript>().speed = new Vector3(shootBulletSpeed, 0);
        newBullets[1].GetComponent<BulletScript>().speed = new Vector3(-shootBulletSpeed, 0);
        newBullets[2].GetComponent<BulletScript>().speed = new Vector3(0, shootBulletSpeed);
        newBullets[3].GetComponent<BulletScript>().speed = new Vector3(0, -shootBulletSpeed);
    }
}
