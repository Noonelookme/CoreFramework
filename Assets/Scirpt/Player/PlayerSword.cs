using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSword : MonoBehaviour
{
    Vector3 position;//���������λ��
    private int attackPower;//������
    public int knockback;//����������
    public GameObject power1;
    public GameObject power2;
    public GameObject power3;
    public int x = 0;
    // Start is called before the first frame update

    private void Awake()
    {
    
    }
    void Start()
    {
        position = transform.localPosition;
    }
    
     void Update()
    {
        if(x<2)
        {
            power1.SetActive(false);
            power2.SetActive(false);
            power3.SetActive(false);
        }
        else if (x >= 2&& x<4)
        {
            power1.SetActive(true);
            power2.SetActive(false);
            power3.SetActive(false);
        }
        else if(x>=4 && x<6)
        {
            power1.SetActive(true);
            power2.SetActive(true);
            power3.SetActive(false);
        }
        else
        {
            power1.SetActive(true);
            power2.SetActive(true);
            power3.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R)&&x>=2)
        {
            x = x - 2;
        }
    }
    public void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            transform.localPosition = position;//������ʱ����
        }
        else
        {
            transform.localPosition = new Vector3(-position.x, position.y, position.z);//������ʱ��ת
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageble damageble = collider.GetComponent<IDamageble>();//�ж��Ƿ�Ϊ���Ե���������

        if (damageble != null)
        {
            Vector3 _position = transform.parent.position;
            Vector2 direction = collider.transform.position - _position;//����ʱ����ҵ�λ�÷����򵯿������ǽ���λ��
            if (x < 6) x++;
            attackPower = 1;
            damageble.OnHit(attackPower, direction.normalized * knockback);
        }
    }

}
