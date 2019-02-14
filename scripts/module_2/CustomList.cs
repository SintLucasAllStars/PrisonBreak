using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomList<T>
{
    
    T[] names;
    private int count;

    public CustomList()
    {
        names = new T[6];
        count = 0;
    }
    
    public void Add(T value)
    {
        if (count < names.Length)
        {
            names[count] = value;
        }
        else
        {
            T[] newNames;
            newNames = new T[names.Length+6];
            for (int i = 0; i < names.Length; i++)
            {
                newNames[i] = names[i];
            }

            newNames[count - 1] = value;

            names = newNames;
        }
        count++;
    }

    public int Count()
    {
        return count;
    }

    public T Get(int index)
    {
        return names[index];
    }
}
