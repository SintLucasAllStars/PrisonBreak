using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildInteraction : MonoBehaviour, IInteractable {
	//Allows for multiple colliders for the same function (Main function is in the parent of the object)
	public void Interact(bool instant = false){
		transform.parent.GetComponent<IInteractable> ().Interact(instant);
	}
}
