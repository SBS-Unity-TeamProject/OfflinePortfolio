using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStates playerStates;
    [SerializeField] Transform Arrow;
    PlayerController _playerController;
    public static Vector2 InputVector2;
    private Arrow _arrow;
    private float exp;
    private int Level;
    private float timer = 0f;
    private float speed = 0.3f;
    public Scanner scanner;
    SpriteRenderer spriter;
    //Rigidbody2D rigid;
    Animator anim;

    public int currentHealth;

    void Awake()
    {
        currentHealth = playerStates.MaxHealth;
        //rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();  
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        _arrow = GetComponent<Arrow>();
    }

    void Update()
    {
        InputVector2.x = Input.GetAxisRaw("Horizontal");
        InputVector2.y = Input.GetAxisRaw("Vertical");
        timer += Time.deltaTime;
        if(timer > speed)
        {
            timer = 0f;
            PlayerAttack();
        }
    }

    private void PlayerAttack()
    {
        if(!scanner.nearestTarget)
        {
            return;
        }

        Vector3 targetPos = _playerController.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform Arrow = GameManager.Instance.transform;
        Arrow.position = transform.position;
        Arrow.rotation = Quaternion.FromToRotation(Vector3.up,dir);
        Arrow.GetComponent<Arrow>().Init(_arrow.damage, _arrow.penetrate, Vector3.zero);
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
