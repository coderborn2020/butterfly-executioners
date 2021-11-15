using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterShootScript : MonoBehaviour
{
    // bullet that bob will shoot
    public GameObject bulletPrefab;

    public float shootBulletSpeed;
    public float shootBulletPeriod = 2f;
    private float nextActionTime = 0.0f;

    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime = Time.time + shootBulletPeriod;
            // execute block of code here
            ShootBullets();
        }
    }

    void ShootBullets()
    {
        List<GameObject> newBullets = new List<GameObject>();
        for (int i = 0; i < 2; i++)
        {
            newBullets.Add(Instantiate(bulletPrefab, transform.position, Quaternion.identity));
        }
        var speedToPlayer = (player.transform.position - transform.position).normalized * shootBulletSpeed;
        newBullets[0].GetComponent<BulletScript>().speed = speedToPlayer;
        speedToPlayer = (player.transform.position - transform.position).normalized * (shootBulletSpeed*0.75f);
        newBullets[1].GetComponent<BulletScript>().speed = speedToPlayer;
    }
}
