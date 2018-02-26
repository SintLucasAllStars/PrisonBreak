using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IInteractable {

	public int id;
	public float openSpeed = 1;
	bool open = false;
	public bool moving = false;
	Vector3 targetRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.rotation.eulerAngles != targetRotation && Mathf.Abs(transform.rotation.eulerAngles.y - targetRotation.y) % 360 > openSpeed )
		{
			moving = true;
			Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), openSpeed);
			transform.rotation = newRotation;
		}
		else
		{
			moving = false;
		}
	}

	public void Open() {
		if(!open)
		{
			open = true;
			//transform.Rotate(new Vector3(0, -90, 0));
			targetRotation = transform.rotation.eulerAngles + new Vector3(0, -90, 0);
		}
	}

	public void Close() {
		if(open)
		{
			open = false;
			//transform.Rotate(new Vector3(0, 90, 0));
			targetRotation = transform.rotation.eulerAngles + new Vector3(0, 90, 0);
		}


	}

	public void Interact(){
		if(InventoryManager.instance.CanOpenDoor(id) && !moving){
			if(open)
			{
				Close();
			}
			else
			{
				Open();
			}
		}
	}
}
