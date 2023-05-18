using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField] private float _speed = 0.5f;
    void Update(){
        float x =Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(x,0,z).normalized * _speed);
    }


}