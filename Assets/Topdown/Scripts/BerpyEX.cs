using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerpyEX : MonoBehaviour
{

    public float slowSpeed = 5f;
    public float fastSpeed = 10f;
    public float angleChangeRate = 145f; // degrees per second
    public float slowFireRate = 0.5f;
    public float fastFireRate = 0.25f;
    public GameObject bulletPrefab;
    private float slowAngle;
    private float fastAngle;
    private float slowShootableTime = 0f;
    private float fastShootableTime = 0f;
    private EnemyBaseScript baseScript;
    private EnemyDieController healthComp;

    // Start is called before the first frame update
    void Start()
    {
        healthComp = GetComponent<EnemyDieController>();
        baseScript = GetComponent<EnemyBaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float health = healthComp.health;
        fastAngle -= angleChangeRate*Time.deltaTime;
        if (health > 20)
        {
            // most generic danmaku pattern ever
            slowAngle += angleChangeRate*Time.deltaTime*0.5f;
            
            if (Time.time > slowShootableTime && baseScript.SeesPlayer)
            {
                slowShootableTime = Time.time + slowFireRate;
                ShootSlow();
            }
            if (Time.time > fastShootableTime && baseScript.SeesPlayer)
            {
                fastShootableTime = Time.time + fastFireRate;
                ShootFast();
            }
        }
        else
        {
            if (Time.time > fastShootableTime && baseScript.SeesPlayer)
            {
                fastShootableTime = Time.time + fastFireRate;
                float angle = Random.Range(0, 360);
                for (int i = 0; i < 5; i++)
                {

                    float offsetSpeed = i*0.5f;
                    var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    newBullet.GetComponent<BulletScript>().speed = DegreeToVector2(angle)*(fastSpeed+offsetSpeed);
                }
            }

        }
    }

    // https://answers.unity.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
    // likely want to move this to a Util script
    static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    void ShootSlow()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.localScale = new Vector3(2, 2, 2);
        bullet.GetComponent<BulletScript>().speed = DegreeToVector2(slowAngle)*slowSpeed;
    }

    void ShootFast()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().speed = DegreeToVector2(fastAngle)*fastSpeed;
    }
}
