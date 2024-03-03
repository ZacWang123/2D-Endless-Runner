using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rend;
    Sprite flippedPlayer, crouchedPlayer, standingPlayer, flippedCrouchedPlayer;

    float jump = 400;
    bool gravitySwitch;
    bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        flippedPlayer = Resources.Load<Sprite>("Player/Flipped_Player");
        crouchedPlayer = Resources.Load<Sprite>("Player/Crouched_Player");
        standingPlayer = Resources.Load<Sprite>("Player/Standing_Player");
        flippedCrouchedPlayer = Resources.Load<Sprite>("Player/Flipped_Crouched_Player");
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
            if (gravitySwitch)
            {
                rend.sprite = flippedPlayer;
            }
            else if (!gravitySwitch)
            {
                rend.sprite = standingPlayer;
            }
            rb.gravityScale = rb.gravityScale * -1;
            jump = jump * -1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (gravitySwitch)
            {
                rend.sprite = flippedCrouchedPlayer;
            }
            else if (!gravitySwitch)
            {
                rend.sprite = crouchedPlayer;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            if (gravitySwitch)
            {
                rend.sprite = flippedPlayer;
            }
            else if (!gravitySwitch)
            {
                rend.sprite = standingPlayer;
            }
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
