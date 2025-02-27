using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWord : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    private void AddNewItem()
    {
        if (!playerInventory.listItem.Contains(thisItem))
        {
            //playerInventory.listItem.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            for (int i = 0; i < playerInventory.listItem.Count; i++)
            {
                if (playerInventory.listItem[i] == null)
                {
                    playerInventory.listItem[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;  
        }
        InventoryManager.RefreshItem();
    }
}
