using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{
    public int points;

    public BonusItem(string name, float weight, int points) : base(name, weight)
    {
        this.points = points;
    }
}
