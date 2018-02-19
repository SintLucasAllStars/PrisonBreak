using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessItem : Item {
	//properties
	private int doorId;

	//constructor
	public AccessItem(string name, int weight, int doorId) : base(name, weight)
	{
		this.doorId = doorId;
	}

	//methods
	public bool OpensDoor(int id)
	{
		return doorId == id;
	}
}
