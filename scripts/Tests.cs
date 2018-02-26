using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool TestInvetoryAdd()
	{
		Debug.Log("======== Testing inventory add ========");
		InventoryManager.instance.AddItem(new AccessItem("Key 1", 2, 1));
		InventoryManager.instance.AddItem(new BonusItem("Bonus 1", 2, 1));
		InventoryManager.instance.AddItem(new AccessItem("Key 2", 2, 1));

		InventoryManager.instance.PrintToConsole();

		if(InventoryManager.instance.Count() == 3)
		{
			Debug.Log("======== Test Passed ========");
			return true;
		}
		else
		{
			Debug.Log("======== Test failed ========");
			return false;
		}
	}
}
