using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(h, v).normalized * 8 * Time.deltaTime;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Orb")
        {
            GameObject.Find("XPBar").GetComponent<MinecraftXPBar>().currentXP += collision.gameObject.GetComponent<MinecraftXP>().xpamount;
            Destroy(collision.gameObject);
        }
    }
}
