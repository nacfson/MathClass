using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperateBulletScript : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float aliveTime = 2f;
    Rigidbody rb;
    
    public void Shoot()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(nameof(TimeCheck));
        rb.AddForce(transform.right * speed, ForceMode.Impulse);
    }

    IEnumerator TimeCheck()
    {
        float t = 0;
        while (t < aliveTime)
        {
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
