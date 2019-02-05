using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestInventory();
    }

    void TestInventory()
    {
        BonusItem bonus = new BonusItem("Bonus1", 2f, 100);
        AccessItem key = new AccessItem("Key1", 2f, 1);
        BonusItem anvil = new BonusItem("anvil", 9f, 900);

        
        Debug.Log("Adding bonus success: " + Inventory.instance.AddItem(bonus));
        Debug.Log("Adding key success: " + Inventory.instance.AddItem(key));
        Debug.Log("Adding Anvil success: " + Inventory.instance.AddItem(anvil));
        Debug.Log("");
        Debug.Log("INVENTORY:");
        Inventory.instance.printToConsole();
        
        Inventory.instance.removeItem(bonus);
        Debug.Log("INVENTORY (after removing):");
        Inventory.instance.printToConsole();
        
        Inventory.instance.removeItem(anvil);
        Debug.Log("INVENTORY (after FAKE removing):");
        Inventory.instance.printToConsole();
    }
}
