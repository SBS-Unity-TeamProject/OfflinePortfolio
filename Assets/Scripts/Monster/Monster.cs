using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Spawmer;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    [SerializeField] GameObject monster;
    private Rigidbody2D target;

    [SerializeField] MonsterExp monsterExp;

    bool _isLive;

    public bool isBoss = false;
    [SerializeField] GameObject Exp;
    [SerializeField] GameObject
        BanditGloves, BanditBoots, BanditArmor,
        BattleGuardHelm, BattleGuardGloves, BattleGuardBoots, BattleGuardArmor,
        DarkMountainHelm, DarkMountainGloves, DarkMountainBoots, DarkMountainArmor,
        GreyKnightGloves, GreyKnightBoots, GreyKnightArmor,
        ManticoreHelm, ManticoreGloves, ManticoreBoots, ManticoreArmor,
        AllStatsArmor, ArmorHelm, AttackHelm, SpeedHelm,
        ScoutHelm, ScoutGloves, ScoutBoots, ScoutArmor;
    GameObject newExp;
    GameObject newExpScript;

    bool isLive = true;
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait;

    private void Update()
    {
        
    }


    void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>() ;


        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
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
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            return;
        }
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if(health > 0)
        {
            anim.SetTrigger("Hit");
        }

        else
        {
            Dead();
        }
    }

    IEnumerator KnockBack()
    {
        yield return wait; // 1������ ����
        Vector3 PlayerPos = GameManager.Instance.player.transform.position;
        Vector3 dirVec = transform.position - PlayerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }

    public void OnDeath()
    {
        newExp = Instantiate(Exp, transform.position, Quaternion.identity);
        Exp exp = newExp.GetComponent<Exp>();
        //����ġ/������ ����ġ 5��
        if (monster.name == "FlyingEye")
        {
            if (isBoss)
            {
                exp.Init(monsterExp.FlyingEye * 5);
            }
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
            if (isBoss)
            {
                exp.Init(monsterExp.EvilWizard2 * 5);
            }
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
            if (isBoss)
            {
                exp.Init(monsterExp.MartialHero * 5);
            }
            exp.Init(monsterExp.MartialHero);

        }

        Destroy(monster);
    }
}
