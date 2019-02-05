using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float range = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Interact();
        }
    }

    void Interact()
    {
        Ray r = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(r, out hit, range))
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);
            IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
            if (i != null)
            {
                i.Action();
            }
        }
    }
}
