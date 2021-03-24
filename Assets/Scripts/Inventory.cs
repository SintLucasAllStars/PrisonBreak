using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float currentWeight;
    public float maxWeight;
    public List<GameObject> itemsInInventory = new List<GameObject>();

    public void RemoveItem(GameObject itemToRemove)
    {
        if (currentWeight >= maxWeight)
        {
            currentWeight = currentWeight - itemToRemove.GetComponent<Item>().weight;

            print(itemToRemove.name + " has been dropped");
            itemsInInventory[itemsInInventory.Count - 1].transform.position = new Vector3(transform.position.x, transform.position.y, transform.localPosition.z + 9);
            itemsInInventory.Remove(itemToRemove);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeight = currentWeight - itemsInInventory[itemsInInventory.Count-1].GetComponent<Item>().weight;
            itemsInInventory[itemsInInventory.Count - 1].transform.position = transform.position;
            itemsInInventory.Remove(itemsInInventory[itemsInInventory.Count-1]);
        }
    }
}
