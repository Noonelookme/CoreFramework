using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
     Rigidbody2D rb;//����
     SpriteRenderer spriteRenderer;//����
     DetectionZone detectionZone;
     Animator animator;//����


    public float speed;//�ٶ�
    public float knockbackForce;
    public int attactPower;//�˺�
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
            //����̽�⵽�����λ�ü�ȥ���������λ��
            if (direction.magnitude <= detectionZone.viewRadius)//�ж�����Ƿ��ڼ��뾶����
            {
                rb.AddForce(direction.normalized * speed);//�õ��ķ�������ٶȽ����ƶ�
                if(direction.x < 0)
                {
                    spriteRenderer.flipX = true;//����Ϊx�Ḻ���򲻷�ת
                }
                else
                {
                    spriteRenderer.flipX = false;//����Ϊx��������ת
                }
                OnWalk();//�������߶���
            }else
            {
                OnWalkStop();//���þ�ֹ����
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
