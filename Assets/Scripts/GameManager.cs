using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // 시간에 따른 소환 레벨 ( 20.초 )
    [Header(" # Game Control ")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header(" # Player info ")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 };

    [Header(" # Gameobject ")]
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

    //public void GetExp()
    //{
    //    exp++;

    //    if(exp == nextExp[level])
    //    {
    //        level++;
    //        exp = 0;
    //    }
    //}
}
