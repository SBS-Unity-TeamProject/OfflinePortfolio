using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Spawner;
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
    //[SerializeField]
    //public GameObject
    //    BanditGloves, BanditBoots, BanditArmor,
    //    BattleGuardHelm, BattleGuardGloves, BattleGuardBoots, BattleGuardArmor,
    //    GreyKnightGloves, GreyKnightBoots, GreyKnightArmor, SilverRing, GoldRing1, GoldRing2;
    //public bool BanditGlovesBool, BanditBootsBool, BanditArmorBool,
    //    BattleGuardHelmBool, BattleGuardGlovesBool, BattleGuardBootsBool, BattleGuardArmorBool,
    //    GreyKnightGlovesBool, GreyKnightBootsBool, GreyKnightArmorBool, SilverRingBool, GoldRing1Bool, GoldRing2Bool;
    GameObject newExp;
    //public bool ABanditGlovesBool, ABanditBootsBool, ABanditArmorBool,
    //    ABattleGuardHelmBool, ABattleGuardGlovesBool, ABattleGuardBootsBool, ABattleGuardArmorBool,
    //    AGreyKnightGlovesBool, AGreyKnightBootsBool, AGreyKnightArmorBool, ASilverRingBool, AGoldRing1Bool, AGoldRing2Bool;
    GameObject newExpScript;

    bool isLive = true;
    Rigidbody2D rigid;
    Collider2D coll;
    Animator anim;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait;
    Stage stage;
    private float r;
    private void Update()
    {
        
    }


    void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>() ;
        r = Random.Range(0.01f, 100f);

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
    }
    private void Start()
    {
        //BanditArmorBool = false;
        //BanditGlovesBool = false;
        //BanditBootsBool = false;
        //BattleGuardHelmBool = false;
        //BattleGuardArmorBool = false;
        //BattleGuardGlovesBool = false;
        //BattleGuardBootsBool = false;
        //GreyKnightArmorBool = false;
        //GreyKnightGlovesBool=false;
        //GreyKnightBootsBool = false;
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
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        if (!isBoss)
        {
            speed = data.speed;
        }
        else if (isBoss)
        {
            speed = data.speed / 10 * 7;
        }
        maxHealth = data.health;
        health = data.health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !isLive)
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if(health > 0)
        {
            anim.SetTrigger("Hit");
        }
        else 
        {  
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            spriter.sortingOrder = 1;
            anim.SetBool("Dead", true);
            GameManager.Instance.kill++;
            GameManager.Instance.GetExp();
        }
    }

    IEnumerator KnockBack()
    {
        yield return wait; // 1프레임 쉬기
        Vector3 PlayerPos = GameManager.Instance.player.transform.position;
        Vector3 dirVec = transform.position - PlayerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }


    public void Dead()
    {
        newExp = Instantiate(Exp, transform.position, Quaternion.identity);
        Exp exp = newExp.GetComponent<Exp>();
        //DropItem();
        //보스는 경험치 5배
        if (monster.name == "FlyingEye")
        {
            if (isBoss)
            {
                exp.Init(monsterExp.FlyingEye * 5);
                stage.timerOn = true;
            }
            else { exp.Init(monsterExp.FlyingEye); }
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
                stage.timerOn = true;
            }
            else { exp.Init(monsterExp.EvilWizard2); }
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
                stage.timerOn = true;
            }
            else { exp.Init(monsterExp.MartialHero); }

        }

        Destroy(monster);
    }

    private void Rand()
    {
        r = Random.Range(0.01f, 100f);
    }
    //일단 보류
    //private void DropItem()
    //{
    //    int ItemCount = 0;
    //    Rand();
    //    if (ItemCount <= 3)
    //    {
    //        if (r <= 3.3f)
    //        {
    //            Instantiate(BanditArmor, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            Destroy(BanditArmor, 1.5f);
    //            BanditArmorBool = true;
    //            ItemCount++;
    //        }
    //        else if (r > 3.3f && r <= 6.6f)
    //        {
    //            Instantiate(BanditBoots, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy(BanditBoots, 1.5f);
    //            BanditBootsBool = true;
    //        }
    //        else if (r > 6.6f && r <= 10f)
    //        {
    //            Instantiate(BanditGloves, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy(BanditGloves, 1.5f);
    //            BanditGlovesBool = true;
    //        }
    //    }
    //    else if (ItemCount <= 6 && ItemCount > 3)
    //    {
    //        if (r <= 2)
    //        {
    //            Instantiate(BattleGuardArmor, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy(BattleGuardArmor , 1.5f);
    //            BattleGuardArmorBool = true;
    //        }
    //        else if (r > 2 && r <= 5)
    //        {
    //            Instantiate(BattleGuardBoots, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy(BattleGuardBoots , 1.5f);

    //            BattleGuardBootsBool = true;
    //        }
    //        else if (r > 5 && r <= 7.5f)
    //        {
    //            Instantiate(BattleGuardGloves, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy(BattleGuardGloves , 1.5f);

    //            BattleGuardGlovesBool = true;
    //        }
    //        else if (r > 7.5f && r <= 10)
    //        {
    //            Instantiate(BattleGuardHelm, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy( BattleGuardHelm, 1.5f);

    //            BattleGuardHelmBool = true;
    //        }
    //    }
    //    else if (ItemCount > 6 && ItemCount <= 9)
    //    {
    //        if (r <= 3.3)
    //        {
    //            Instantiate(GreyKnightArmor, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy(GreyKnightArmor , 1.5f);
    //            GreyKnightArmorBool = true;
    //        }
    //        else if (r > 3.3 && r <= 6.6)
    //        {
    //            Instantiate(GreyKnightBoots, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy( GreyKnightBoots, 1.5f);
    //            GreyKnightBootsBool = true;
    //        }
    //        else if (r > 6.6 && r <= 10)
    //        {
    //            Instantiate(GreyKnightGloves, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    //            ItemCount++;
    //            Destroy(GreyKnightGloves , 1.5f);
    //            GreyKnightGlovesBool = true;
    //        }
    //    }
    //}

}
