using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour , IInteractable {

	public enum ItemType{Access, Bonus, Consumable, RaftPart}

	public ItemType itemType;
	public float weight;
	public int activationID;
	public int score;
	public int PartID;

	public GameBehaviour.ItemUses use;
	System.Func<int, bool> useFunc;
	public int input;

	Item item = null;

	Item CreateItem(){
		if (item != null)
			return item;
		switch (itemType) {
		case ItemType.Access:
			return new Access (gameObject.name, weight, activationID);
		case ItemType.Consumable:
			return new Consumable (gameObject.name, weight, 1, GameBehaviour.gb.itemUses[(int)use], input);
		case ItemType.Bonus:
			return new Bonus (gameObject.name, weight, score);
		case ItemType.RaftPart:
			return new RaftPart (gameObject.name, weight,PartID);
		}
		return null;
	}

	public void Interact(bool instant = false){
		if (GameBehaviour.im.AddInv (CreateItem ()))
			Destroy (this.gameObject);
	}

	public void SetItem(Item i){item = i;}

}
