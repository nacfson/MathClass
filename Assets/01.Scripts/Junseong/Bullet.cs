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

    private void CheckOtherEnemy(Vector3 dir, Vector3 hitPoint) //�÷��̾ �� �Ѿ� ���� ����
    {
        Collider[] enemys = Physics.OverlapSphere(hitPoint, radius, 1 << LayerMask.NameToLayer("Enemy"));
        for (int i = 0; i < enemys.Length; i++)
        {
            Vector2 myDir = (enemys[i].transform.position - hitPoint).normalized; // ���� ������ ���� �ȿ� �ִ� ���� ���� ����
            float myAngle = Mathf.Acos(Vector3.Dot(inputDir, myDir)) * Mathf.Rad2Deg;// ������ ������ ACOs�� ����       
            if (myAngle < attackAngleRange) ;//������
            else; //�ȸ�����
        }
    }

    private void SeperateBullet()
    {
            
    }



}
