using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 100;
    private float timer;
    private GameManage gameManage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManage>(); 
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            Destroy(gameObject);
        }
        rb.velocity = Vector2.left * (speed + gameManage.objectSpeed);
    }
}
