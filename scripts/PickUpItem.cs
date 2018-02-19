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

	public void Interact(){
		Debug.Log("Interacting with pickup item");
	}
}
