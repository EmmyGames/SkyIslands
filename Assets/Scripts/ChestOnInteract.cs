using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChestOnInteract : MonoBehaviour, IInteractable
{
    public Image interactImage;
    //public Image getItemImage;
    //public Item getItem;
    public Item useItem;
    //public bool interactable = true;
    public AudioManager audioManager;
    public GameObject getItem;
    private Vector3 _offset = new Vector3(0,1.5f,0);
    
    private void Start()
    {
        //getItemImage.enabled = false;
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
            if (InventoryScript.inventory[i].id == useItem.id)
            {
                audioManager.PlaySound("interact");
                Instantiate(getItem, transform.position + _offset, Quaternion.Euler(0, 90, -90));
                Destroy(gameObject);

                /*audioManager.PlaySound("pickup");
                getItem.AddItem(getItem);
                getItem.DisplayItem(getItemImage);
                interactable = false;*/
            }
        }

        //Destroy(gameObject);
    }

    public void OnEndHover()
    {
        interactImage.enabled = false;
    }
}
