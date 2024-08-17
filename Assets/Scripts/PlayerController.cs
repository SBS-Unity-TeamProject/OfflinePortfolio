using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStates playerStates;
    [SerializeField] public GameObject StatUPWindow;
    public static Vector2 InputVector2;
    SpriteRenderer spriter;
    //Rigidbody2D rigid;
    Animator anim;
    
    public int currentExp = 0;
    public int Level;
    public int expForLevelUp;
    public float defaultStatUP = 1;


    private void Start()
    {
        Level = 0;
        expForLevelUp = 0;
        playerStates.Strength = 10;
        playerStates.MoveSpeed = 5;
        playerStates.MaxHealth = 100;
        playerStates.Armor = 0;
        playerStates.Range = 2f;
        playerStates.AttackSpeed = 1f;
}
    public void ExpUp(int n)
    {
        currentExp += n;
        int i = 35;
        if (expForLevelUp <= currentExp)
        {
            currentExp = currentExp - expForLevelUp;
            StatUPWindow.SetActive(true);
            Level++;


            if (Level > 1)
            {
                expForLevelUp += i;
                i += 15;
                defaultStatUP += 0.5f;
            }
            else if (Level == 1)
            {
                expForLevelUp = 20;
            }
        }
    }

    public int currentHealth;

    void Awake()
    {
        currentHealth = ((int)playerStates.MaxHealth);
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
