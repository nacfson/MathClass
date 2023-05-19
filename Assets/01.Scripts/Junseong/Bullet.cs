using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5f;
    [SerializeField] private float radius = 3f;
    [SerializeField] Rigidbody rb;
    [SerializeField] float attackAngleRange = 120f;
    Vector3 inputDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector2 dir)
    {
        inputDir = dir.normalized;
        rb.velocity = inputDir * m_Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            SeperateBullet();
            CheckOtherEnemy(inputDir, collision.contacts[0].point);
        }

    }

    private void CheckOtherEnemy(Vector3 dir, Vector3 hitPoint) //플레이어가 쏜 총알 방향 벡터
    {
        Collider[] enemys = Physics.OverlapSphere(hitPoint, radius, 1 << LayerMask.NameToLayer("Enemy"));
        for (int i = 0; i < enemys.Length; i++)
        {
            Vector2 myDir = (enemys[i].transform.position - hitPoint).normalized; // 맞은 곳에서 범위 안에 있는 적을 향한 벡터
            float myAngle = Mathf.Acos(Vector3.Dot(inputDir, myDir)) * Mathf.Rad2Deg;// 각도를 구한후 ACOs에 넣음       
            if (myAngle < attackAngleRange) ;//맞은거
            else; //안맞은거
        }
    }

    private void SeperateBullet()
    {
            
    }



}
