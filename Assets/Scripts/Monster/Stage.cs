using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField]
    GameObject
        Boss1, Boss2, Boss3;
    public bool timerOn;
    public float timeSinceStart = 0f;
    Vector3 BossSpawnVector;
    Vector3 BossSpawnVectorPlus;
    void Start()
    {
        BossSpawnVectorPlus = new Vector3(0,5,0);
        BossSpawnVector = player.transform.position;
        timerOn = true;
        timeSinceStart = 0;
    }
    void Update()
    {
        BossSpawnVector += BossSpawnVectorPlus;
        if (timerOn)
        {
            timeSinceStart = Time.realtimeSinceStartup;
        }
    }
    private void LateUpdate()
    {
        if (180 <=timeSinceStart && timeSinceStart < 360)
        {
            timerOn = false;
            Boss(1);
        }
        else if (360 <= timeSinceStart && timeSinceStart <540)
        {
            timerOn = false;
            Boss(2);
        }
        else if (540 <= timeSinceStart)
        {
            timerOn = false;
            Boss(3);
        }
    }
    private void Boss(int BossNumber)
    {
        switch (BossNumber)
        {
            default: break;
            case 1:
                Instantiate(Boss1, BossSpawnVector, Quaternion.identity);
                break;
            case 2:
                Instantiate(Boss2, BossSpawnVector, Quaternion.identity);
                break;
            case 3:
                Instantiate(Boss3, BossSpawnVector, Quaternion.identity);
                break;
        }
    }


}
