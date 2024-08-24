using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnDatas;

    int level;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / 10f), spawnDatas.Length - 1);
        if (timer > spawnDatas[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject Monster = GameManager.Instance.pool.Get(0);
        Monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        Monster.GetComponent<Monster>().Init(spawnDatas[level]);
    }

    [System.Serializable]
    public class SpawnData
    {
        public int spriteType;
        public float spawnTime;
        public int health;
        public float speed;
    }
}
