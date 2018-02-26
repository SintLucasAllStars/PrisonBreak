using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable {

	public enum ItemType {accessItem, bonusItem};

	public ItemType itemType;
	public string name;
	public int weight;
	public int doorId;
	public int bonusPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private Item createItem(){

		Item it = null;

		switch(itemType)
		{
		case ItemType.accessItem:
			it = new AccessItem(name, weight, doorId);
			break;
		case ItemType.bonusItem:
			it = new BonusItem(name, weight, bonusPoints);
			break;
		}

		return it;
	}

	public void Interact(){
		if(InventoryManager.instance.AddItem(createItem()))
		{
			Destroy(gameObject);
		}
	}
}
