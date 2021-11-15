using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerShootScript : MonoBehaviour
{

    // bullet that bob will shoot
    public GameObject bulletPrefab;

    public float shootBulletSpeed;
    public float shootBulletPeriod = 1.5f;
    private float nextActionTime = 0.0f;

    private float offset = 0.0f;
    public float offsetChange = 5.0f;
    
    public int spreadCount = 8;
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        offset+=offsetChange*Time.deltaTime;
        if(offset > 360) offset = 0;
        if (Time.time > nextActionTime ) {
            nextActionTime = Time.time + shootBulletPeriod;
            // execute block of code here
            ShootBullets();
        }
    }

    void ShootBullets()
    {
        List<GameObject> newBullets = new List<GameObject>();
        for (int i = 0; i < spreadCount; i++)
        {
            var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            float angle = 360/spreadCount*i;
            newBullet.GetComponent<BulletScript>().speed = DegreeToVector2(angle+offset)*shootBulletSpeed;
        }
    }

    static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}
