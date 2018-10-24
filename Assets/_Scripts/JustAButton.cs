using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustAButton : MonoBehaviour {
	
	int inventoryID;

	public void OnMouse_Down(){
		if (GameBehaviour.im.Use_DropObject (inventoryID,GameBehaviour.gb.holdLMB))
			GameBehaviour.im.UpdateInventory ();
	}

	public void SetInventoryID(int ID){inventoryID = ID;}
	public int GetInventoryID(){return inventoryID;}
}
