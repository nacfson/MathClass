using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour{
    [SerializeField] private Material _attackMat;
    [SerializeField] private Material _criticalMat;
    private Material _originMat;
    MeshRenderer _meshRenderer;

    private void Awake() {
        _meshRenderer = GetComponent<MeshRenderer>();
        _originMat = _meshRenderer.material;

    }

    public void Damaged(bool isCritical){
        StartCoroutine(ChangeColor(isCritical));
    }

    private IEnumerator ChangeColor(bool isCritical){
        var wfs = new WaitForSeconds(1f);
        if(isCritical){
            _meshRenderer.material = _criticalMat;
            yield return wfs;
            _meshRenderer.material = _originMat;
        }
        else{
            _meshRenderer.material = _attackMat;
            yield return wfs;
            _meshRenderer.material = _originMat;

        }
    }
}
