using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] private float health;
    private Collision collision;
    private BulletScript bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<BulletScript>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
