using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinecraftXPBar : MonoBehaviour
{
    [SerializeField]
    GameObject bar;
    [SerializeField]
    TextMeshProUGUI txtCurrentLevel;

    [SerializeField]
    float maxXP;
    float currentXP;

    int level = 1;

    private void Start()
    {
        currentXP = maxXP;
        GetMaxXP();
    }

    private void Update()
    {
        bar.transform.localScale = new Vector3(currentXP / maxXP, 1, 1);
        txtCurrentLevel.SetText(level.ToString());

        if(currentXP / maxXP >= 1)
        {
            level++;
            currentXP = currentXP - maxXP;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentXP += 5;
            Debug.Log("curXP: "+currentXP);
            Debug.Log("level: " + level);
        }

        GetMaxXP();
    }

    void GetMaxXP()
    {
        if(level >= 0 && level <= 16)
        {
            maxXP = level * level + 6f * level;
        }
        else if(level >= 17 && level <= 31)
        {
            maxXP = (2.5f * level) * level - 40.5f * level + 360f;
        }
        else if(level >= 32)
        {
            maxXP = (4.5f * level) * level - 162.5f * level + 2220f;
        }
    }
}
