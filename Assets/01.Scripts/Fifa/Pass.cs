using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour{
    [SerializeField] private GameObject _ball;
    private float x;
    private float y;

    void Update(){
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x,0,y);

        if(Input.GetKeyDown(KeyCode.S)){
            Debug.Log(dir);
            PassBall(transform.position + dir);
        }
    }

    [SerializeField] private LayerMask _layerMask;
    public void PassBall(Vector3 dir){
        Collider[] cols = Physics.OverlapSphere(transform.position,1000f,_layerMask);

        Collider nearCol = null;
        foreach(Collider col in cols){
            if(nearCol == null){
                nearCol = col;
            }

            float a = Vector3.Dot(dir, col.transform.position - transform.position);
            float b= Vector3.Dot(dir, nearCol.transform.position -transform.position);

            if(a < b){
                nearCol = col;
            }
        }
        _ball.transform.position = nearCol.transform.position;
    }
}