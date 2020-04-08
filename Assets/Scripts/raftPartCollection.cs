using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raftPartCollection : MonoBehaviour
{
    public int raftBuildingProgress;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("raftPart"))
        {
            raftBuildingProgress++;
            other.transform.position = new Vector3(0, -1000, 0);
        }
    }
}
