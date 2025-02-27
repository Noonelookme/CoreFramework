using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
     Rigidbody2D rb;//物体
     SpriteRenderer spriteRenderer;//方向
     DetectionZone detectionZone;
     Animator animator;//动画


    public float speed;//速度
    public float knockbackForce;
    public int attactPower;//伤害
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectionZone = GetComponent<DetectionZone>();
        animator = GetComponent<Animator>();
    }

  private void FixedUpdate()
    {
        if (detectionZone.detectedObjs != null)
        {

            Vector2 direction = (detectionZone.detectedObjs.transform.position - transform.position);
            //怪物探测到的玩家位置减去怪物自身的位置
            if (direction.magnitude <= detectionZone.viewRadius)//判断玩家是否在检测半径以内
            {
                rb.AddForce(direction.normalized * speed);//得到的方向乘上速度进行移动
                if(direction.x < 0)
                {
                    spriteRenderer.flipX = true;//方向为x轴负方向不反转
                }
                else
                {
                    spriteRenderer.flipX = false;//方向为x轴正方向反转
                }
                OnWalk();//调用行走动画
            }else
            {
                OnWalkStop();//调用静止动画
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        IDamageble damageble = collider.GetComponent<IDamageble>();

        if (damageble != null && collider.tag == "Player")
        {
            Vector2 direction = collider.transform.position - transform.position;
            Vector2 force = direction.normalized * knockbackForce;

            damageble.OnHit(attactPower, force);
        }

    }

    public void OnWalk()
    {
        animator.SetBool("isWalking", true);
    }

    public void OnWalkStop()
    {
        animator.SetBool("isWalking", false);
    }
   void OnDamage()
    {
        animator.SetTrigger("isDamage");
    }
    void OnDie()
    {
        animator.SetTrigger("isDead");
    }
}
