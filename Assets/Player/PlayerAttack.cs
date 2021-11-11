using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private ButterflyMove butterflyMove;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private float bulletDamage;
    private float coolDownTimer = Mathf.Infinity;

    private void Awake()
    {
        butterflyMove = GetComponent<ButterflyMove>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTimer > attackCooldown)
             Attack();

            coolDownTimer += Time.deltaTime;
        
    }

    private void Attack()
    {
        Debug.Log("Shoot");
        coolDownTimer = 0;

        bullets[0].transform.position = firePoint.position;
        bullets[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
