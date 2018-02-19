using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item {
	//properties
	private int value;

	//constructor
	public BonusItem(string name, int weight, int value) : base(name, weight)
	{
		this.value = value;
	}

	//methods
	public int GetValue(){
		return value;
	}
}
