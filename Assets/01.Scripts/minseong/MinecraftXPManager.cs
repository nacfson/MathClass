using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecraftXPManager : MonoBehaviour
{
    [SerializeField]
    GameObject xpPrefab;

    [SerializeField]
    Transform minT;
    [SerializeField]
    Transform maxT;

    float curTime;

    private void Update()
    {
        curTime -= Time.deltaTime;
        if(curTime < 0)
        {
            curTime = Random.Range(0.7f, 1.3f);
            GameObject instance = Instantiate(xpPrefab, new Vector3(Random.Range(minT.position.x, maxT.position.x), 
                                                                    Random.Range(minT.position.y, maxT.position.y)), Quaternion.identity);
            instance.GetComponent<MinecraftXP>().OrbLevel = (int)Random.Range(1,6);
        }
    }
}
