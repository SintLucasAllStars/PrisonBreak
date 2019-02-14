using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour
{
    private List<int> myList;
    
    // Start is called before the first frame update
    void Start()
    {
        myList = new List<int>();
        
        Debug.Log(myList.Capacity);

        for (int i = 0; i < 100000; i++)
        {
            myList.Add(1); 
        }
        
        
        Debug.Log(myList.Capacity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
