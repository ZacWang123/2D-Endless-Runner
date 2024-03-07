using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public GameObject[] spawnObject;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns = 1.5f;
    public float maxTimeBetweenSpawns = 0.75f;
    public int counter;
    public int randNum;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timeBetweenSpawns > maxTimeBetweenSpawns) 
        {
            timeBetweenSpawns -= Time.deltaTime / 200;
        }
        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            if (counter >= 5)
            {
                counter = 0;
                randNum = Random.Range(3,5);
            }
            else
            {
                randNum = Random.Range(0, 3);
            }
            Debug.Log(randNum);
            Instantiate(spawnObject[randNum], spawnPoints[randNum].transform.position, Quaternion.identity);
            counter += 1;
        }
    }
}
