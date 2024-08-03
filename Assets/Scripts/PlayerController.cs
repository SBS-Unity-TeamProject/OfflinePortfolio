using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    static public Vector2 InputVector2;
    public float speed = 5;
    //SpriteRenderer spriter;

    void Update()
    {
        
        InputVector2.x = Input.GetAxisRaw("Horizontal");
        InputVector2.y = Input.GetAxisRaw("Vertical");
        Vector2 MoveVector2 = InputVector2.normalized * speed * Time.deltaTime;
        MoveTranslate(new Vector2(MoveVector2.x, MoveVector2.y));
    }


    //void FixedUpdate()
    //{
        
    //}

    private void MoveTranslate(Vector2 moveVector)
    {
        transform.Translate(moveVector);
    }

    //private void LateUpdate()
    //{
    //    if(InputVector2.x != 0)
    //    {
    //        spriter.flipX = InputVector2.x < 0;
    //    }
    //}
}
