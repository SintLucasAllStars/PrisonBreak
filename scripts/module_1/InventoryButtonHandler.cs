using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryButtonHandler : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    
    public void HandleClick()
    {
        //Debug.Log("Removing " + transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        Inventory.instance.removeByName(transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        player.SetInventoryVisible(false);
    }
}
