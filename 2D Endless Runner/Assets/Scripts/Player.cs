using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Boolean isGrounded;
    Boolean switchGravity;
    Vector2 velocity;
    float gravity = 900;
    float jumpVelocity = 300;
    float groundHeight = -80;
    float ceilingHeight = 80;

    void Start()
    {
    }

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

        if (switchGravity)
            if (Input.GetKeyDown(KeyCode.W))
            {
                switchGravity = false; 
                isGrounded = false;
                gravity = gravity * -1;
                velocity.y = jumpVelocity;
                jumpVelocity = jumpVelocity * -1;
            }

        if (isGrounded)
        {
            switchGravity = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!isGrounded)
        {
            pos.y += velocity.y * Time.fixedDeltaTime;
            velocity.y -= gravity * Time.fixedDeltaTime;

            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }

            if (pos.y >= ceilingHeight)
            {
                pos.y = ceilingHeight;
                isGrounded = true;
            }
        }
        transform.position = pos;
    }
}
