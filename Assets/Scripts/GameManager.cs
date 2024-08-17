using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // �ð��� ���� ��ȯ ���� ( 20.�� )
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
