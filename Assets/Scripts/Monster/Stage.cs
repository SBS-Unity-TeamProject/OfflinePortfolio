using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField]
    GameObject
        Boss1, Boss2, Boss3;
    [SerializeField] public GameObject spawner;
    public bool timerOn;
    public float timeSinceStart = 0f;
    Vector3 BossSpawnVector;
    Vector3 BossSpawnVectorPlus;
    int bossN = 0;
    void Start()
    {
        BossSpawnVectorPlus = new Vector3(0,5,0);
        BossSpawnVector = player.transform.position;
        timerOn = true;
        timeSinceStart = 0;
    }
    void Update()
    {
        BossSpawnVector = player.transform.position;
        if (timerOn)
        {
            timeSinceStart = Time.realtimeSinceStartup;
        }
    }
    private void LateUpdate()
    {
        if (180 <=timeSinceStart && timeSinceStart < 360)
        {
            BossSpawnVector += BossSpawnVectorPlus;
            timerOn = false;
            spawner.SetActive(false);
            bossN++;
            Boss(1);
        }
        else if (360 <= timeSinceStart && timeSinceStart <540)
        {
            BossSpawnVector += BossSpawnVectorPlus;
            spawner.SetActive(false );
            timerOn = false;
            bossN++;
            Boss(2);
        }
        else if (540 <= timeSinceStart)
        {
            BossSpawnVector += BossSpawnVectorPlus;
            spawner.SetActive(false );
            timerOn = false;
            bossN++;
            Boss(3);
        }
    }
    private void Boss(int BossNumber)
    {
        switch (BossNumber)
        {
            default: break;
            case 1:
                if (bossN == 1)
                {
                    Instantiate(Boss1, BossSpawnVector, Quaternion.identity);
                }
                break;
            case 2:
                if ( bossN == 2)
                {
                    Instantiate(Boss2, BossSpawnVector, Quaternion.identity);                    
                }
                break;
            case 3:
                if (bossN == 3)
                {
                    Instantiate(Boss3, BossSpawnVector, Quaternion.identity);
                }
                break;
        }
    }


}
