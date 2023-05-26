using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ApheliosEnemy : MonoBehaviour
{
    Material NormalMat;
    Material HitMat;
    MeshRenderer meshRender;

    public bool isHit = false;
    private float m_radius;
    private float m_attackAngleRange;
    private Vector3 m_dir;
    public float AttackAngleRange => m_attackAngleRange;
    
    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
        NormalMat = GetComponent<MeshRenderer>().material;
    }
    public void CheckOtherEnemy(Vector3 dir, Vector3 hitPoint, float radius, float attackAngleRange, Material HitMat) //플레이어가 쏜 총알 방향 벡터
    {
        m_radius = radius;
        m_attackAngleRange = attackAngleRange;
        m_dir = dir;
        this.HitMat = HitMat;

        Collider[] enemys = Physics.OverlapSphere(hitPoint, radius, 1 << LayerMask.NameToLayer("ENEMY"));
        for (int i = 0; i < enemys.Length; i++)
        {
            Vector2 myDir = (enemys[i].transform.position - hitPoint).normalized; // 맞은 곳에서 범위 안에 있는 적을 향한 벡터
            float myAngle = Mathf.Acos(Vector3.Dot(dir, myDir)) * Mathf.Rad2Deg;// 각도를 구한후 ACOs에 넣음       
            if (myAngle < attackAngleRange * 0.5f)
            {
                enemys[i].gameObject.GetComponent<ApheliosEnemy>().Twinkle(HitMat);
            }//맞은거
        }
    }
    
    public void Twinkle(Material mat)
    {
        meshRender.material = mat;
        StartCoroutine("Twinkling");
    }

    private IEnumerator Twinkling()
    {
        float t = 0f;
        Color color = meshRender.material.color;
        int twinkleCnt = 0;
        int maxTwinkleCnt = 3;
        bool firstIn = false;
        while(true)
        {
            if (twinkleCnt >= maxTwinkleCnt) break;
            color.a = Mathf.Cos(t * 10) / 2 + 0.5f;
            
            if (color.a >= 0.95f && firstIn == true)
            {
                firstIn = false;
                twinkleCnt++;
            }
            if(color.a < 0.95f) firstIn = true;
          
            meshRender.material.color = color;
            t += Time.deltaTime;
            yield return null;
        }
        meshRender.material = NormalMat;
    }

    public void SetValue()
    {
        isHit = true;
        StopAllCoroutines();
        StartCoroutine(DelayCoroutine(0.5f));
    }

    IEnumerator DelayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay); 
        isHit = false;

    }
}
