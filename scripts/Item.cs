using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item {
	//Properties
	public string name;
	public int weight;

	//Constructor
	public Item (string name, int weight)
	{
		this.name = name;
		this.weight = weight;
	}
		
	//Methods

}
