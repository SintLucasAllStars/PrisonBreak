using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElongatedRaft : MonoBehaviour
{
    public GameObject ElongatedRaftModel;
    public raftPartCollection raftParts;

    void Start()
    {
        raftParts = raftPartCollection.raftPartCollection;
    }
    void Update()
    {
        if (raftParts.raftBuildingProgress == 4)
        {
            transform.position = new Vector3(70, 1, 5);
        }
    }
}
