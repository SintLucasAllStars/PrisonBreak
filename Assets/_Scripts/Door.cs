using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable {

	public int doorID;
	public bool reverse = false;

	bool open = false;
	bool moving = false;

	void Awake(){
		if (transform.parent.gameObject.isStatic)
			gameObject.isStatic = false;
	}

	public void Interact(bool instant = false){
		if (!moving  && (instant || doorID == 0 || GameBehaviour.im.HasAccess (doorID)))
			StartCoroutine (InteractDoor ());
	}

	IEnumerator InteractDoor(){
		moving = true;
		float timeBackup = Time.time + 0.5f;
		Quaternion target = Quaternion.Euler (transform.parent.rotation.eulerAngles + new Vector3 (0f, 90f * (reverse ? -1f:1f), 0f) * (open ? 1f : -1f));
		while( transform.parent.rotation != target && Time.time  < timeBackup){
			transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, target, 4f);
			yield return 0;
		}
		transform.parent.rotation = target;
		open = !open;
		moving = false;
	}

	public void SetID(int ID){doorID = ID;}
	public int GetID(){return doorID;}
}
