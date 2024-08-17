using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // 시간에 따른 소환 레벨 ( 20.초 )
    public float gameTime;
    public float maxGameTime = 1 * 10f;

    public PoolManager pool;
    public PlayerController player;

    void Awake()
    {
        Instance = this;

        Initialize();
    }

    protected void Initialize()
    {
        GameObject obj = GameObject.FindWithTag("Player");
        if (obj)
        {
            player = obj.GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
