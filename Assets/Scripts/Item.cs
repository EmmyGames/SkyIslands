using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ite", menuName = "Item")]
public class Item : ScriptableObject
{
    public int id;
    public int quantity;
    
    public void AddItem(Item newItem)
    {
        foreach (var item in InventoryScript.inventory.Where(item => item.id == newItem.id))
        {
            item.quantity++;
            Debug.Log("Increased quantity");
            return;
        }
        InventoryScript.inventory.Add(newItem);
        Debug.Log("Added " + newItem + " to inventory");
    }

    public void LoseItem(Item item)
    {
        for(var i = 0; i < InventoryScript.inventory.Count; i++)
        {
            if (InventoryScript.inventory[i] == item)
            {
                InventoryScript.inventory.RemoveAt(i);
            }
        }
    }
}
