 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float sprintMultiplier;
    float trueSpeed;

    Rigidbody rb;
    Vector3 direction;

    public int health = 5;
    Text healthDisplay;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //healthDisplay = GameObject.Find("healthDisplay").GetComponent<Text>();

        //healthDisplay.text = "HP : " + health.ToString();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            trueSpeed = speed * sprintMultiplier;
        }
        else
        {
            trueSpeed = speed;
        }

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        direction = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = direction * trueSpeed * Time.deltaTime;
    }
}