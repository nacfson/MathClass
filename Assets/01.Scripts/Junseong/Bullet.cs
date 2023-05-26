using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5f;
    [SerializeField] Rigidbody rb;
    ApheliosAttack attack;
    Vector3 inputDir;
    float radius;
    float attackRange;

    [SerializeField] Material HitMat;
    private void Awake()
    {
        attack = GameObject.Find("Player").GetComponent<ApheliosAttack>();
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector2 dir)
    {
        inputDir = dir.normalized;
        rb.velocity = inputDir * m_Speed;
    }

    public void SetValue(float radius, float attackRange, Vector2 dir)
    {
        this.radius = radius;
        this.attackRange = attackRange;
        this.inputDir = dir;
    }

    float t = 0;
    private void Update()
    {
        t += Time.deltaTime;
        if (t > 4)
        {
            attack.ShootingInit();
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            SeperateBullet();
            attack.ShootingInit();
            collision.gameObject.GetComponent<ApheliosEnemy>().CheckOtherEnemy(inputDir, collision.contacts[0].point, radius, attackRange, HitMat);
            Destroy(this.gameObject);
        }

    }
    private void SeperateBullet()
    {
            
    }
}
