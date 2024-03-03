using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float jump = 400;
    bool gravitySwitch;
    bool isGrounded;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
         
    }

    void Update()
    {
        if (Input.GetButton("Jump") && isGrounded) 
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            gravitySwitch = !gravitySwitch;
            rb.gravityScale = rb.gravityScale * -1;
            jump = jump * -1;
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
