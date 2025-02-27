using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
     static InventoryManager Instance;

    public Inventory myBag;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public TextMeshProUGUI itemInfomation;
    public List<GameObject> slots = new List<GameObject>();

     void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }
    private void OnEnable()
    {
        RefreshItem();
        Instance.itemInfomation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        Instance.itemInfomation.text = itemDescription;
    }
    /*public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(Instance.slotPrefab,Instance.slotGrid.transform.position,Quaternion.identity);
        newItem.gameObject.transform.SetParent(Instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotIamge.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/

    public static void RefreshItem()
    {
        for (int i = 0; i < Instance.slotGrid.transform.childCount; i++)
        {
            if (Instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(Instance.slotGrid.transform.GetChild(i).gameObject);
            Instance.slots.Clear();

        }
        for (int i = 0; i < Instance.myBag.listItem.Count; i++)
        {
            //CreateNewItem(Instance.myBag.listItem[i]);
            Instance.slots.Add(Instantiate(Instance.emptySlot));
            Instance.slots[i].transform.SetParent(Instance.slotGrid.transform);
            Instance.slots[i].GetComponent<Slot>().SetupSlot(Instance.myBag.listItem[i]);
        }
    }
}
