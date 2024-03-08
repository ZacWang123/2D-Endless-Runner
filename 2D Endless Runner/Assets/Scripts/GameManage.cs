using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public GameObject[] spawnObject;
    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns = 1.5f;
    public float maxTimeBetweenSpawns = 0.75f;
    public int counter;
    public int randNum;
    public float objectSpeed;
    public float gameTimer;
    public Text timeText;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        gameTimer += Time.deltaTime;
        timeText.text = ((int)gameTimer).ToString();

        if (objectSpeed < 150) 
        {
            objectSpeed += Time.deltaTime * 2;
        }

        if (timeBetweenSpawns > maxTimeBetweenSpawns) 
        {
            timeBetweenSpawns -= Time.deltaTime / 200f;
        }
        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            if (counter >= 5)
            {
                counter = 0;
                randNum = Random.Range(4,6);
            }
            else
            {
                randNum = Random.Range(0, 4);
            }
            Debug.Log(randNum);
            Instantiate(spawnObject[randNum], spawnPoints[randNum].transform.position, Quaternion.identity);
            counter += 1;
        }
    }
}
