using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision other)
	{
		IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
	
		if(interactable != null)
		{
			interactable.Interact();
		}
	}
}
