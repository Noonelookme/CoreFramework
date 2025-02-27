using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
 
    Vector2 moveInput; //����
  
    public float moveSpeed;//�����ٶ�
    Animator animator;
    public SpriteRenderer spriteRenderer;

    public GameObject myBag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        OpenMyBag();
    }
    private void OnMove(InputValue value)//��ȡ����ֵ
    {
        moveInput = value.Get<Vector2>();
        if (moveInput==Vector2.zero)//�ж�����Ƿ�ֹ
        {
            animator.SetBool("isWalking",false);//��ֹʱ���߶����ر�

        }
        else
        {
            animator.SetBool("isWalking", true);//����ʱ���߶�������
            if(moveInput.x < 0)//ת���ж�
            {
                
               spriteRenderer.flipX = true; //����Ϊx������ʱ����ת
               gameObject.BroadcastMessage("IsFacingRight", false);
              
            }
            if(moveInput.x > 0)
            {
                spriteRenderer.flipX = false; //����Ϊx������ʱ��ת
                gameObject.BroadcastMessage("IsFacingRight", true);
             
            }
            
            
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveSpeed);//��rbʩ���Ϸ������ٶȾ������ƶ�
    }
   void OnFire()
    {
        animator.SetTrigger("swordAttack");//���Ź�������
    }
    void OnDamage()
    {
       
    }
    void OnDie()
    {
        animator.SetTrigger("isDead");//������������
    }
    #region Animation Method

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    #endregion
    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            myBag.SetActive(!myBag.activeSelf);
            //if (myBag.activeSelf)
            //{
            //    GetComponent<UIManager>().PanelFadeIn();
            //}
        }
    }
}
