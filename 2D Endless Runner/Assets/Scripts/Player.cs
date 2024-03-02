using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Boolean gravitySwitch;
    Boolean isGrounded;
    Boolean switchGravity;
    Vector2 velocity;
    float gravity = 1500;
    float jumpVelocity = 450;
    float groundHeight = -80;
    float ceilingHeight = 80;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject ground = GameObject.Find("Ground");
    }


    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
            }
        }

        /*
        if (switchGravity)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                switchGravity = false;
            }
        }
        */
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!isGrounded)
        {
            pos.y += velocity.y * Time.fixedDeltaTime;
            velocity.y += -gravity * Time.fixedDeltaTime;

            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }

            /*
            if (gravitySwitch)
            {
                if (pos.y >= groundHeight)
                {
                    isGrounded = true;
                }
            }

            if (!gravitySwitch)
            {
                pos.y += velocity.y * Time.fixedDeltaTime;
                velocity.y += gravity * Time.fixedDeltaTime;

                if (pos.y <= groundHeight)
                {
                    isGrounded = true;
                }
            }
            */

            transform.position = pos;
            }

        /*
        {
        gravitySwitch = !gravitySwitch;

        if (gravitySwitch)
        {
            rb.gravityScale = -gravity;
        }
        else if (!gravitySwitch)
        {
            rb.gravityScale = gravity;
        }
        }
        */
    }
}
