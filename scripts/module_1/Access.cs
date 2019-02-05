using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Access : Pickup
{
    public int door;
    
    protected override Item CreateItem()
    {
        return new AccessItem(objectName, weight, door);
    }
}
