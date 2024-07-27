using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 InputVector2;
    public float speed = 5;
    //SpriteRenderer spriter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputVector2.x = Input.GetAxis("Horizontal");
        InputVector2.y = Input.GetAxis("Vertical");
        Vector2 MoveVector2 = InputVector2 * speed * Time.deltaTime;
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
