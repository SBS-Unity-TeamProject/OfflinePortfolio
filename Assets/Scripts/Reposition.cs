using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Area"))
            return;
        
        //Vector3 playerPos = GameManager.Instance.player.transform.position;
        //Vector3 myPos = transform.position;
        //float diffX =Mathf.Abs(playerPos.x - myPos.x);
        //float diffY = Mathf.Abs(playerPos.x - myPos.y);
        // ����Ż ���� : ���� ����� ( �켭����ũ ) 17:07
    }
}
