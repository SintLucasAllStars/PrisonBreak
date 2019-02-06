using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{

    public float range = 2f;

    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Interact();
        }
        
        if (Input.GetButtonDown("Inventory"))
        {
            SetInventoryVisible(!InventoryUI.instance.gameObject.activeSelf);
        }
    }

    public void SetInventoryVisible(bool value)
    {
        InventoryUI.instance.gameObject.SetActive(value);
        GetComponent<FirstPersonController>().enabled = !value;
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;  
    }

    void Interact()
    {
        Ray r = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        int ignorePlayer =~ LayerMask.GetMask("Player");
        
        if (Physics.Raycast(r, out hit, range, ignorePlayer))
        {    
            //Debug.Log("Hit " + hit.collider.gameObject.name);
            IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
            if (i != null)
            {
                i.Action();
            }
        }
    }
}
