using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump")) 
        {
            rb.velocity = new Vector3(0, 50f, 0);
        }
    }
}
