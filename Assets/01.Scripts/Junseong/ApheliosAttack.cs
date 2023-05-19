using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApheliosAttack : MonoBehaviour
{
    [SerializeField] Bullet bullet;

    private void Awake()
    {
               
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Camera.main.WorldToScreenPoint(Input.mousePosition);
            Vector3 dir = mousePos - transform.position;
            Bullet spawnBul = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnBul.Shoot(dir);
        }    
    }

}
