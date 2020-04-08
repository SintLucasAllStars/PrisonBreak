using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    string requiredKey;
    [SerializeField]
    GameObject player;

public void open()
    {
        List<GameObject> tempItemInInventory = new List<GameObject>();
        tempItemInInventory = player.GetComponent<Inventory>().itemsInInventory;
        for (int i = 0; i < tempItemInInventory.Count; i++)
        {
            if (tempItemInInventory[i].GetComponent<Item>().name == requiredKey && tempItemInInventory[i].GetComponent<Item>().accessItem == true)
            {
                transform.position = new Vector3(0, -1000, 0);
            }

        }
    }
}
