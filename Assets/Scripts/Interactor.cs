using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public int raftBuildingProgress;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            player.GetComponent<Inventory>().itemsInInventory.Add(other.gameObject);
            other.transform.position = new Vector3(0, -1000, 0);
            player.GetComponent<Inventory>().currentWeight = player.GetComponent<Inventory>().currentWeight + other.gameObject.GetComponent<Item>().weight;
            player.GetComponent<Inventory>().RemoveItem(other.gameObject);
        }
        if (other.gameObject.CompareTag("door"))
        {
            other.GetComponent<Door>().open();
        }
    }

    private void Update()
    {
        if (raftBuildingProgress == 4)
        {

        }
    }
}
