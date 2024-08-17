using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject monster;
    private Rigidbody2D target;
    [SerializeField] MonsterExp monsterExp;
    public bool isBoss = false;
    [SerializeField] GameObject Exp;
    GameObject newExp;
    GameObject newExpScript;
    bool isLive = true;
    Rigidbody2D rigid;
    SpriteRenderer spriter;

    private void Update()
    {
        
    }


    void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>() ;


        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
        { 

            return;
        }

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
        {
            return;
        }
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
    }

    public void OnDeath()
    {
        newExp = Instantiate(Exp, transform.position, Quaternion.identity);
        Exp exp = newExp.GetComponent<Exp>();
        if (monster.name == "FlyingEye")
        {
            exp.Init(monsterExp.FlyingEye);
        }
        else if (monster.name == "Goblin")
        {
            exp.Init(monsterExp.Goblin);

        }
        else if (monster.name == "Mushroom")
        {
            exp.Init(monsterExp.Mushroom);

        }
        else if (monster.name == "Skeleton")
        {
            exp.Init(monsterExp.Skeleton);

        }
        else if (monster.name == "EvilWizard1")
        {
            exp.Init(monsterExp.EvilWizard1);

        }
        else if (monster.name == "EvilWizard2")
        {
            exp.Init(monsterExp.EvilWizard2);

        }
        else if (monster.name == "EvilWizard3")
        {
            exp.Init(monsterExp.EvilWizard3);

        }
        else if (monster.name == "HeroKnight1")
        {
            exp.Init(monsterExp.HeroKnight1);

        }
        else if (monster.name == "HeroKnight2")
        {
            exp.Init(monsterExp.HeroKnight2);

        }
        else if (monster.name == "MartialHero")
        {
            exp.Init(monsterExp.MartialHero);

        }

        Destroy(monster);
    }
}
