using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ApheliosEnemy))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        ApheliosEnemy brain = target as ApheliosEnemy;
        //float rad = (180 - brain.AttackAngleRange) * 0.5f * Mathf.Deg2Rad;
        //Vector3 angle = new Vector3(Mathf.Sin(rad), Mathf.Cos(rad), 0);

        //Handles.color = Color.white;
        //Handles.DrawWireDisc(brain.transform.position, Vector3.forward, brain.AttackAngleRange);

        //Handles.color = new Color(1, 1, 1, 0.5f);
        //Handles.DrawSolidArc(brain.transform.position,
        //    Vector3.forward * -1,
        //    angle,
        //    brain.AttackAngleRange,
        //    brain.AttackAngleRange);

        //GUIStyle style = new GUIStyle();
        //style.fontSize = 35;
        //Handles.Label(brain.transform.position + brain.transform.up * 2f, brain.AttackAngleRange.ToString(), style);
    }
}
