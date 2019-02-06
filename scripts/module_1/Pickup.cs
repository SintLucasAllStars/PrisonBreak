using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractable
{
    public string objectName;
    public float weight;
    public Sprite image;
    private GameObject inventoryObj;

    void Start()
    {
        InventoryUI.instance.RegisterPickUpItem(this);
    }
    
    public void Action()
    {
        if (Inventory.instance.AddItem(CreateItem()))
        {
            gameObject.SetActive(false);
        }
    }

    public bool isInInventory()
    {
        return inventoryObj != null;
    }

    public void setInventoryObj(GameObject go)
    {
        inventoryObj = go;
    }

    public void removeInventoryObj()
    {
        Destroy(inventoryObj);
        inventoryObj = null;
    }

    public void Respawn()
    {
        removeInventoryObj();
        transform.position = Camera.main.transform.position + Camera.main.transform.forward;
        gameObject.SetActive(true);
    }

     protected abstract Item CreateItem();
}
