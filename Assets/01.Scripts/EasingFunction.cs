using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingFunction : MonoBehaviour
{
    public float duration = 1f;
    public float maxRange = 100f;
    public GameObject projectile;
    public Transform firePoint;
    public Transform targetPos;
    public Material projectileMat;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastQ(targetPos.position);
        }
    }

    public void CastQ(Vector3 targetPos)
    {
        StartCoroutine(MoveProjectile(targetPos));
    }
    private IEnumerator MoveProjectile(Vector3 targetPos)
    {
        Vector3 startPos = firePoint.position;
        float time = 0f;

        while(time < duration)
        {
            float t = time / duration;
            float easedT = EaseInCirc(t);

            Vector3 newPos = Vector3.Lerp(startPos, targetPos, easedT);
            projectile.transform.position = newPos;

            float alpha = 1 - easedT;
            SetMaterialAlpha(alpha);

            time += Time.deltaTime;
            yield return null;
        }
    }
    private float EaseInCirc(float t)
    {
        //return Mathf.Pow(2, 10 * (t - 1));
        //return t * t * t * t;
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 1));
    }
    private void SetMaterialAlpha(float alpha)
    {
        if(projectileMat!=null)
        {
        Color color = projectileMat.color;
        color.a = alpha;
        projectileMat.color = color;
        }
    }
}
