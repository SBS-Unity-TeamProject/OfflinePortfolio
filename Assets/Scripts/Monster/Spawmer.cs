using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawmer : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f) 
        {
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject Monster = GameManager.Instance.pool.Get(Random.Range(0, 2));
        Monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
