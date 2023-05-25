using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatColor : MonoBehaviour
{
    Renderer targetColor;
    public GameObject frontCube;
    public GameObject leftCube;
    public GameObject rightCube;
    public GameObject backCube;
    private void Awake()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Projectile")&&transform.position.z < 1)
        {
            
            targetColor.material.color = Color.blue;
        }
        if (collision.collider.CompareTag("Projectile") && transform.position.x < -1)
        {
            targetColor.material.color = Color.red;
        }
    }
}
