using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugenMap : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y); // y 좌표를 올바르게 비교

        // TODO : 코드 수정
        //Vector2 playerDir = Move.InputVector2; // static 변수로 직접 접근

        //float dirX = playerDir.x < 0 ? -1 : 1;
        //float dirY = playerDir.y < 0 ? -1 : 1;

        //switch (transform.tag)
        //{
        //    case "Ground":
        //        if (diffX > diffY)
        //        {
        //            transform.Translate(Vector3.right * dirX * 40);
        //        }
        //        else if (diffX < diffY)
        //        {
        //            transform.Translate(Vector3.up * dirY * 40);
        //        }
        //        break;
        //    case "Enemy":
        //        // 적 관련 로직 추가
        //        break;
        //}
    }
}