using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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
}
