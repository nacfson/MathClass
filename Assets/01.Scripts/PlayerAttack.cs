using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{
    [SerializeField] private Transform _enemyForward;

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Attack();
        }
    }

    private void Attack(){
        Collider[] col = Physics.OverlapSphere(transform.position,10f);

        
    }
}
