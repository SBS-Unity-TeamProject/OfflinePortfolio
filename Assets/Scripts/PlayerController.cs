using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public PlayerStates playerStates;
    public static Vector2 InputVector2;
    static public Vector2 InputVector2;
    private float exp;
    private int Level;
    SpriteRenderer spriter;
    //Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        //rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();  
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        InputVector2.x = Input.GetAxisRaw("Horizontal");
        InputVector2.y = Input.GetAxisRaw("Vertical");
    }

    private void PlayerAttack()
    {
        
    }


    void FixedUpdate()
    {
        Vector2 MoveVector2 = InputVector2.normalized * playerStates.MoveSpeed * Time.deltaTime;
        MoveTranslate(new Vector2(MoveVector2.x, MoveVector2.y));
    }

    private void MoveTranslate(Vector2 moveVector)
    {
        transform.Translate(moveVector);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", InputVector2.magnitude);

        if (InputVector2.x != 0)
        {
            spriter.flipX = InputVector2.x < 0;
        }
    }
    public void GetExp()
    {
        exp++;

        if(exp == 1)
        {
            Level++;
            exp = 0;
        }
    }
}
