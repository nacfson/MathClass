using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ApheliosAttack : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] private float radius = 3f;
    [SerializeField] float attackAngleRange = 120f;
    [SerializeField] CreateMesh _CM;
    float addAngleValue = 3f;
    public float AttackAngleRange => attackAngleRange;
    LineRenderer lineRender;
    public bool isHit;
    public bool isShooting;
    public bool Iscreate;
    Vector3 dir;
    KeyCode Shift = KeyCode.LeftShift;

    private void Awake()
    {
        lineRender = GetComponent<LineRenderer>();          
    }

    RaycastHit hit;
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        dir = (mousePos - transform.position).normalized;
        dir.z = 0;
        // out, ref
        //bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance);
        isHit = Physics.Raycast(transform.position,
                                dir,
                                out hit, 20, 1 << LayerMask.NameToLayer("ENEMY"));

        lineRender.SetPosition(0, transform.position);
        if (Input.GetKey(Shift))
        {
            if (isShooting)
            {
                lineRender.enabled = false;
            }
            else
            {
                lineRender.enabled = true;
                if (isHit)
                {
                    lineRender.SetPosition(1, hit.point);
                    if(!Iscreate)
                    {
                        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        CreateMesh currentMesh = Instantiate<CreateMesh>(_CM, hit.point, Quaternion.identity);
                        currentMesh.transform.rotation = Quaternion.AngleAxis(angle + AttackAngleRange/2, Vector3.forward);
                        currentMesh.NormalAttack(transform, AttackAngleRange, radius); 
                    }
                }
                else
                {
                    lineRender.SetPosition(1, transform.position + dir * 20);
                }
            }
        }
        else
        {
            Iscreate = false;
            lineRender.enabled = false;
        }
 
        if (Input.GetKey(KeyCode.Mouse0) && !isShooting)
        {
            isShooting = true; 
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Bullet spawnBul = Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
            spawnBul.Shoot(dir);
            spawnBul.SetValue(radius, attackAngleRange, dir);
            //Invoke("ShootingInit", 1.5f);
        }    
    }

    public void ShootingInit()
    {
        Invoke(nameof(SetShootingValue), 0.5f);
    }

    private void SetShootingValue()
    {
        isShooting = false;
    }

  
    private void OnDrawGizmos()
    {
        if (Input.GetKey(Shift))
        {
            if (isHit && !isShooting)
            {
                Handles.color = new Color(0.5f,1, 1, 0.5f);
                // DrawSolidArc(시작점, 노멀벡터(법선벡터), 그려줄 방향 벡터, 각도, 반지름)
                Handles.DrawSolidArc(hit.point, Vector3.forward, dir, attackAngleRange / 2, radius);
                Handles.DrawSolidArc(hit.point, Vector3.forward, dir, -attackAngleRange / 2, radius);
            }
        }
    }

}
