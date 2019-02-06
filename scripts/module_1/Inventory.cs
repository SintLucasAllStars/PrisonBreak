using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private List<Item> items;
    public float maximumWeight = 10.0f;
    public float totalWeight;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
        
        items = new List<Item>();
    }

    public bool AddItem(Item item)
    {
        if (totalWeight + item.weight > maximumWeight)
        {
            return false;
        }
        else
        {
            items.Add(item);
            InventoryUI.instance.Add(item);
            totalWeight += item.weight;
            return true;
        }
    }

    public void removeItem(Item item)
    {
        if (items.Remove(item))
        {
            InventoryUI.instance.Remove(item);
            totalWeight -= item.weight;
        }
    }

    public void removeByName(string name)
    {
        foreach (Item i in items)
        {
            if (i.name == name)
            {
                removeItem(i);
                break;
            }
        }
    }

    public bool HasKey(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] is AccessItem)
            {
                AccessItem it = (AccessItem) items[i];
                if (it.door == id)
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    public void printToConsole()
    {
        foreach (Item i in items)
        {
            Debug.Log(i.name + "--" + i.weight);
        }
        
        Debug.Log("Total Weight:" + totalWeight);
    }
}