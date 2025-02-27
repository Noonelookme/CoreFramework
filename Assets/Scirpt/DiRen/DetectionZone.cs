using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public Collider2D detectedObjs;//接收扫描的的玩家位置
    public float viewRadius;//搜索敌人时的扫描半径
    public LayerMask playerLayerMask;//搜索敌人的标签
    // Start is called before the first frame update
    void Start()
    {
        img1.SetActive(false);
        img2.SetActive(false);
        img3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);

        if (collider != null)
        {
            detectedObjs = collider;
            img1.SetActive(true);
            img2.SetActive(true);
            img3.SetActive(true);
        }
        else
        {
            img1.SetActive(false);
            img2.SetActive(false);
            img3.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, viewRadius);//显示扫描半径方便处理
    }
}
