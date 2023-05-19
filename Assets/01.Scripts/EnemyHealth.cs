using System.Collections;
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
    void Update(){
        transform.Rotate(Time.deltaTime * 100f * transform.up);
    }

    public void Damaged(bool isCritical){
        StartCoroutine(ChangeColor(isCritical));
        StartCoroutine(ChangeAlpha());
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

    private IEnumerator ChangeAlpha(){
        float timer = 1f;
        float currentTime = 0f;
        while(currentTime < timer){
            currentTime += Time.deltaTime;
            float percent  = currentTime / timer;
            Debug.Log(percent);
            float value = Mathf.Cos((percent + 1 )* 0.25f);
            Color a = _meshRenderer.material.color;
            a.a = value;
            _meshRenderer.material.color = a;
            yield return null;
        }
    }
}
