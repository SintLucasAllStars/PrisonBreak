using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsTests : MonoBehaviour
{
    public CustomList<string> names;
    public CustomList<int> scores;
    
    // Start is called before the first frame update
    void Start()
    {
        names = new CustomList<string>();
        scores = new CustomList<int>();
        //David Bea Sofia
        names.Add("David");
        scores.Add(100);
            
        names.Add("Bea"); 
        scores.Add(99);

        showNames();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            names.Add("Sofia");
            scores.Add(200);
            showNames();
        }
        
    }

    void showNames()
    {
        for (int i = 0; i < names.Count(); i++)
        {
            Debug.Log(names.Get(i) + " === " + scores.Get(i));
        }
    }
}
