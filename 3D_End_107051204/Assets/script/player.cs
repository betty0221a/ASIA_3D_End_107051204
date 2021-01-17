﻿
using UnityEngine;
using Invector.vCharacterController;

public class player : MonoBehaviour
{
    private float hp = 100;
    private Animator ani;

    private int atkCount;

   /// <summary>
   /// 計時器
   /// </summary>
    private float timer;
    [Header("連擊間隔時間"),Range(0,3)]
     public float interval = 1;
    [Header("攻擊中心點")]
    public Transform atkPoint;
    [Header("攻擊長度"), Range(0f, 5f)]
    public float atkLength;
    [Header("攻擊力"), Range(0, 500)]
    public float atk = 30;


    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }
    private void OnDrawGizmos()

    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(atkPoint.position, atkPoint.forward * atkLength);
    }
    private RaycastHit hit;
    private void Attack()
    {
        if(atkCount < 3)
       

        if (timer < interval)

        {
            timer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                atkCount++;
                timer = 0;
                ani.SetInteger("連續攻擊", atkCount);

                    if (Physics.Raycast(atkPoint.position, atkPoint.forward, out hit, atkLength, 1 << 9))
                    {
                        hit.collider.GetComponent<Enemy>().Damage(atk);
                    }
                }
        }
        else
        {
                atkCount = 0;
            timer = 0;
        }
        if (atkCount == 3) atkCount = 0;
        ani.SetInteger("連續攻擊", atkCount);
    }
    /// <summary>
    /// 受傷
    /// </summary>
    public void Damage(float Damage)


    {
        hp -= Damage;
        ani.SetTrigger("受傷觸發");

        if(hp <= 0)
        {
            Dead();
        }
        
        
    }
    private void Dead()
    {
        ani.SetTrigger("死亡觸發");
        vThirdPersonController vt = GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
        vt.lockRotation = true;
    }
}
