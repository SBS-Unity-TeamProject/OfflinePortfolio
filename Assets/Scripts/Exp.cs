using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    PlayerController controller;
    [SerializeField] MonsterExp monsterExp;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller = collision.GetComponent<PlayerController>();
            if (controller)
            {
                controller.ExpUp(monsterExp.a);
                Destroy(gameObject);
            }
        }
    }
}
