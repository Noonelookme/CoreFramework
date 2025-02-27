using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
 
    Vector2 moveInput; //输入
  
    public float moveSpeed;//人物速度
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
    private void OnMove(InputValue value)//获取输入值
    {
        moveInput = value.Get<Vector2>();
        if (moveInput==Vector2.zero)//判断玩家是否静止
        {
            animator.SetBool("isWalking",false);//静止时行走动画关闭

        }
        else
        {
            animator.SetBool("isWalking", true);//行走时行走动画开启
            if(moveInput.x < 0)//转向判断
            {
                
               spriteRenderer.flipX = true; //方向为x负方向时不翻转
               gameObject.BroadcastMessage("IsFacingRight", false);
              
            }
            if(moveInput.x > 0)
            {
                spriteRenderer.flipX = false; //方向为x正方向时翻转
                gameObject.BroadcastMessage("IsFacingRight", true);
             
            }
            
            
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveSpeed);//给rb施加上方向与速度就有了移动
    }
   void OnFire()
    {
        animator.SetTrigger("swordAttack");//播放攻击动画
    }
    void OnDamage()
    {
       
    }
    void OnDie()
    {
        animator.SetTrigger("isDead");//播放死亡动画
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
