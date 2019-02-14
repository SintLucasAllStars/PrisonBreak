using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public GameObject body;
    public GameObject explosion;
    
    public float radius = 10.0F;
    public float power = 3.0F;
    
    public void Boom()
    {
        explosion.SetActive(true);
        body.SetActive(false);
        Destroy(gameObject, 1.5f);
        
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F, ForceMode.Impulse);
        }
    }
}
