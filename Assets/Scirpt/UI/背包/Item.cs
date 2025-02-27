using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/New Item")]

public class Item : ScriptableObject
{
    public string itemName;//��Ʒ��
    public Sprite itemImage;//��ƷͼƬ
    public int itemHeld ;//������Ʒ����
    [TextArea]
    public string itemInfo;//��Ʒ��������

    public bool equip;//�ж���װ������ҩˮ
}
