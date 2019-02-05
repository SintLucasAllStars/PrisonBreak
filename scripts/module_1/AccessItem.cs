using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessItem : Item
{
  public int door;

  public AccessItem(string name, float weight, int door) : base(name, weight)
  {
    this.door = door;
  }
}
