using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DamagebleCharacter : MonoBehaviour, IDamageble
{
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public float health;

    public Image hpImg;
    public Image hpEffectImg;

    public float maxHP;//最大血量
    public float currentHP;//当前血量
    public float buffTime;//缓扣时间
    public int x;
    private Coroutine updateCoroutine;//协程 防止上一次扣血还未完成就开始下一次扣血
    public GameObject a;
   void Start()
    {
      
        UpdateHealthBar();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && a.activeSelf == true)
        {
               Reply();
        }
    }
    public void SetHealth(float health)
    {
        currentHP = Mathf.Clamp(health, 0f, maxHP);
        UpdateHealthBar();
    }
    public  void UpdateHealthBar()
    {
        hpImg.fillAmount = currentHP / maxHP;//fillAmount是图片填充量
        
        if(updateCoroutine != null)//如果已经有协程
        {
            StopCoroutine(updateCoroutine);
        }
        updateCoroutine = StartCoroutine(UpdateHpEffect());
    }

    private IEnumerator UpdateHpEffect()
    {
        float effectLength = hpEffectImg.fillAmount - hpImg.fillAmount;//得到白色血条与红色血条的差值
        float elapsedTime = 0f;
        while (elapsedTime < buffTime && effectLength !=0)
        {
            elapsedTime += Time.deltaTime;//时间每帧增加
            hpEffectImg.fillAmount = Mathf.Lerp(hpImg.fillAmount + effectLength, hpImg.fillAmount, elapsedTime);
            yield return null;//停顿一帧
        }
        hpEffectImg.fillAmount = hpImg.fillAmount;//防止白色血条超过红色血条
    }
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if(value>health && value<= maxHP)
            {
                       health = value;
            }
            else if(value < health)
            {
                health = value;
                if (health <= 0)
                {
                    gameObject.BroadcastMessage("OnDie");
                    Targetable = false;
                }
                else
                {
                    gameObject.BroadcastMessage("OnDamage");
                }
            }
            
        }
    }
    bool targetable;
    public bool Targetable
    {
        get
        {
            return targetable;
        }
        set
        {
            targetable = value;
            if (!targetable)
            {
                rb.simulated = false;
            }
        }
    }
public void OnHit(int damage, Vector2 knockback)
    {
        Health -= damage;
        SetHealth(health);
        rb.AddForce(knockback);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
    private void Reply()
    {
        
        Health += x;
        SetHealth(health);
       
    }
}
