using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecraftXP : MonoBehaviour
{
    GameObject player;
    public int OrbLevel;

    public int xpamount;

    public readonly bool isChasing;

    private void Start()
    {
        switch (OrbLevel)
        {
            case 1:
                xpamount = Random.Range(3, 6);
                transform.localScale = Vector3.one * 0.1f;
                GetComponent<CircleCollider2D>().radius *= 0.1f;
                break;
            case 2:
                xpamount = Random.Range(7, 16);
                transform.localScale = Vector3.one * 0.2f;
                GetComponent<CircleCollider2D>().radius *= 0.2f;
                break;
            case 3:
                xpamount = Random.Range(17, 36);
                transform.localScale = Vector3.one * 0.3f;
                GetComponent<CircleCollider2D>().radius *= 0.3f;
                break;
            case 4:
                xpamount = Random.Range(37, 72);
                transform.localScale = Vector3.one * 0.4f;
                GetComponent<CircleCollider2D>().radius *= 0.4f;
                break;
            case 5:
                xpamount = Random.Range(73, 128);
                transform.localScale = Vector3.one * 0.5f;
                GetComponent<CircleCollider2D>().radius *= 0.5f;
                break;
            case 6:
                xpamount = Random.Range(149, 306);
                transform.localScale = Vector3.one * 0.6f;
                GetComponent<CircleCollider2D>().radius *= 0.6f;
                break;
            default:
                break;
        }

        player = GameObject.Find("Player");
    }

    void Update()
    {

    }

/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        *//*Debug.Log("yam");
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<MinecraftXPBar>().currentXP += xpamount;
            Destroy(gameObject);
        }*//*
    }*/
}
