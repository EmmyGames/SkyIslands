using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyController : MonoBehaviour
{
    public Item getItem;
    public float rotationSpeed;   
    void Update()
    {
        transform.Rotate(2f, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<AudioManager>().PlaySound("pickup");
        getItem.AddItem(getItem);
        //getItem.DisplayItem(getItemImage);
        Destroy(gameObject);
    }
}
