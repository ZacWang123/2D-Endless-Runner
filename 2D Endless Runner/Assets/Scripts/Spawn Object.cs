using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 100;

    private float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            Destroy(gameObject);
        }
        rb.velocity = Vector2.left * speed;
    }
}
