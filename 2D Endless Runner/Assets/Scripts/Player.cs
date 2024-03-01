using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Boolean gravitySwitch;
    float gravity = 70f;
    float jumpVelocity = 300f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump")) 
        {
            if (gravitySwitch)
            {
                rb.velocity = new Vector3(0, -jumpVelocity, 0);
            }
            else if (!gravitySwitch)
            {
                rb.velocity = new Vector3(0, jumpVelocity, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
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
    }
}
