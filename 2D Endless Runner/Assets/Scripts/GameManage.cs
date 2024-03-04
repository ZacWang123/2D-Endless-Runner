using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public GameObject[] spawnObject;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns = 1.5f;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, 2);
            Instantiate(spawnObject[randNum], spawnPoints[randNum].transform.position, Quaternion.identity);
        }
    }
}
