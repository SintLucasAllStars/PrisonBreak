using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    public float maxFallspeed;
    public float speedIncreas;
    float fallSpeed;
    bool falling;
    public float groundCheckRange;
    bool jumping = false;
    public float jumpSpeed;
    public float jumpDecrease;
    float jumpStats = 0;

    void Start()
    {
       
    }

    void Update()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), groundCheckRange))
        {
             
            falling = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.red);
        }
        else
        {
            falling = true;
        }

        if (!jumping && falling)
        {
            if (fallSpeed < maxFallspeed)
            {
                fallSpeed += speedIncreas;
            }
            transform.Translate(0, -fallSpeed * Time.deltaTime, 0);

        }
        else
        {
            fallSpeed = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !falling)
        {
            jumping = true;
            jumpStats = jumpSpeed;
        }

        if (jumping)
        {
            transform.Translate(0, jumpStats, 0);
            jumpStats -= jumpDecrease;
            if (jumpStats < jumpDecrease)
            {
                jumping = false;
            }
        }

    }


}
