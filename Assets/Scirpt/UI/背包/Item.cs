using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/New Item")]

public class Item : ScriptableObject
{
    public string itemName;//物品名
    public Sprite itemImage;//物品图片
    public int itemHeld ;//持有物品数量
    [TextArea]
    public string itemInfo;//物品文字描述

    public bool equip;//判断是装备还是药水
}
