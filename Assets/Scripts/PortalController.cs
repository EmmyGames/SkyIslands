using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour, IInteractable
{
    public Item useItem;
    public Transform teleportTo;
    public bool canTeleport = false;
    public Image interactImage;
    public Image needItemImage;
    public GameObject thePlayer;
    private Vector3 offset = new Vector3(0, 1.08f, 0);
    public AudioManager audioManager;
    
    private void Start()
    {
        interactImage.enabled = false;
    }

    private void Update()
    {
        if (canTeleport)
        {
            if (Input.GetButtonDown("Use"))
            {
                OnInteract();
            }
            interactImage.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTeleport = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTeleport = false;
            interactImage.enabled = false;
            needItemImage.enabled = false;
        }
    }
    
    public float MaxRange
    {
        get { return maxRange; }
    }

    private const float maxRange = 0f;
    
    public void OnStartHover()
    {
        
    }

    public void OnInteract()
    {
        foreach (var t in InventoryScript.inventory)
        {
            if (t.id == useItem.id)
            {
                audioManager.PlaySound("interact");
                thePlayer.transform.position = teleportTo.transform.position + offset;
                //play portal sound
                audioManager.PlaySound("teleport");
                return;
            }
        }
        audioManager.PlaySound("noKey");
        needItemImage.enabled = true;
    }

    public void OnEndHover()
    {
    }
}
