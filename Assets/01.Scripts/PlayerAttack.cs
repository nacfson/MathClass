using UnityEngine;

public class PlayerAttack : MonoBehaviour{
    [SerializeField] private Transform _enemyForward;

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Attack();
        }
    }

    private void Attack(){
        Collider[] cols = Physics.OverlapSphere(transform.position,10f , 1 << LayerMask.NameToLayer("ENEMY"));

        foreach(Collider col in cols){
            float a = Vector3.Dot(transform.forward,(col.transform.forward));

            if(a > 0){
                col.GetComponent<EnemyHealth>().Damaged(false);
            }            
            else{
                col.GetComponent<EnemyHealth>().Damaged(true);
            }
        }
        
    }
}
