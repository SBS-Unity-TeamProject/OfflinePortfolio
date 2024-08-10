using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStates playerStates;
    public static Vector2 InputVector2;
    SpriteRenderer spriter;
    //Rigidbody2D rigid;
    Animator anim;
    public int currentExp = 0;
    public int Level;
    public int expForLevelUpp;
    private void Start()
    {
        Level = 0;
        expForLevelUpp = 0;
    }
    public void ExpUp(int n)
    {
        currentExp += n;
        int i = 35;
        if (expForLevelUpp <= currentExp)
        {
            currentExp = currentExp - expForLevelUpp;
            Level++;
            if (Level > 1)
            {
                expForLevelUpp += i;
                i += 15;
            }
            else if (Level == 1)
            {
                expForLevelUpp = 20;
            }
        }
    }

    public int currentHealth;

    void Awake()
    {
        currentHealth = playerStates.MaxHealth;
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
}
