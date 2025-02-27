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

    public float maxHP;//���Ѫ��
    public float currentHP;//��ǰѪ��
    public float buffTime;//����ʱ��
    public int x;
    private Coroutine updateCoroutine;//Э�� ��ֹ��һ�ο�Ѫ��δ��ɾͿ�ʼ��һ�ο�Ѫ
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
        hpImg.fillAmount = currentHP / maxHP;//fillAmount��ͼƬ�����
        
        if(updateCoroutine != null)//����Ѿ���Э��
        {
            StopCoroutine(updateCoroutine);
        }
        updateCoroutine = StartCoroutine(UpdateHpEffect());
    }

    private IEnumerator UpdateHpEffect()
    {
        float effectLength = hpEffectImg.fillAmount - hpImg.fillAmount;//�õ���ɫѪ�����ɫѪ���Ĳ�ֵ
        float elapsedTime = 0f;
        while (elapsedTime < buffTime && effectLength !=0)
        {
            elapsedTime += Time.deltaTime;//ʱ��ÿ֡����
            hpEffectImg.fillAmount = Mathf.Lerp(hpImg.fillAmount + effectLength, hpImg.fillAmount, elapsedTime);
            yield return null;//ͣ��һ֡
        }
        hpEffectImg.fillAmount = hpImg.fillAmount;//��ֹ��ɫѪ��������ɫѪ��
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
