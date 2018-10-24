using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftBuilding : MonoBehaviour, IInteractable {

	int buildTotalParts = 3;

	public void Interact(bool instant = false) {
		if (CheckBuildParts())
			GameBehaviour.gb.EndGame (true);
	}

	bool CheckBuildParts(){
		int ret = 0;
		PickupItem[] interactableChilderen = GetComponentsInChildren<PickupItem> ();
		foreach (PickupItem pick in interactableChilderen)
			if (pick.itemType == PickupItem.ItemType.RaftPart)
				ret++;
		return (ret == buildTotalParts);
	}
	
	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.CompareTag ("Interactable"))
		if (coll.gameObject.GetComponent<IInteractable> () is PickupItem)
		if (coll.gameObject.GetComponent<PickupItem> ().itemType == PickupItem.ItemType.RaftPart) {
			coll.gameObject.transform.parent = transform;
			coll.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		}
	}
}
