using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Move player;

    void Awake()
    {
        Instance = this;
    }
}
