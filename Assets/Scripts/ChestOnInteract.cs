using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChestOnInteract : MonoBehaviour, IInteractable
{
    public Image interactImage;
    public Image getItemImage;
    public Item getItem;
    public Item useItem;
    public bool interactable = true;
    
    private void Start()
    {
        getItemImage.enabled = false;
        interactImage.enabled = false;
    }
    
    public float MaxRange
    {
        get { return maxRange; }
    }

    private const float maxRange = 100f;
    
    public void OnStartHover()
    {
        interactImage.enabled = true;
    }

    public void OnInteract()
    {
        for(var i = 0; i < InventoryScript.inventory.Count; i++)
        {
            if (interactable && InventoryScript.inventory[i].id == useItem.id)
            {
                getItem.AddItem(getItem);
                getItem.DisplayItem(getItemImage);
                interactable = false;
            }
        }

        //Destroy(gameObject);
    }

    public void OnEndHover()
    {
        interactImage.enabled = false;
    }
}
