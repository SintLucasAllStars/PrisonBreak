using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start ()
    {
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter(Collision Coll)
    {
        if (Coll.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}