using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Exp : MonoBehaviour
{
    PlayerController controller;
    //[SerializeField] MonsterExp monsterExp;
    int ExpAmount = 0;
    
    public void Init(int expAmount)
    {
        ExpAmount = expAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller = collision.GetComponent<PlayerController>();
            if (controller)
            {
                if(ExpAmount == 0)
                {
                    Debug.Log("경험치 량이 초기화가 되지 않았습니다.");
                }
                controller.ExpUp(ExpAmount);
                Destroy(gameObject);
            }
        }
    }
}
