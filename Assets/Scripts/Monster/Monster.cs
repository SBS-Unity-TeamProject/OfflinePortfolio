using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Spawner;
using static UnityEngine.GraphicsBuffer;

public enum EMonsterType
{
    Normal,
    Boss,
}

public class Monster : MonoBehaviour
{
    public float speed;
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
    Damageable damageable;
    private float r;

    [SerializeField] EMonsterType monsterType = EMonsterType.Normal;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>() ;
        r = Random.Range(0.01f, 100f);

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();
        damageable = GetComponent<Damageable>();
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
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
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
        damageable.Health = data.health;
        damageable.MaxHealth = data.health;
        damageable.IsAlive = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !isLive)
            return;

        Bullet bullet = collision.GetComponent<Bullet>();
        if (!bullet) 
            return;

        StartCoroutine(KnockBack());

        int damage = (int)collision.GetComponent<Bullet>().damage;

        damageable.GetHit(damage);
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
        if (monsterType == EMonsterType.Boss)
        {
            SceneManager.LoadScene("GameOverScene");
            //exp.Init(monsterExp.FlyingEye * 5);
            //stage.timerOn = true;
            //stage.spawner.SetActive(true);
        }
        else
        {
            exp.Init(monsterExp.EvilWizard3);
        }

        monster.gameObject.SetActive(false);
    }
    SceneManager SceneManager;
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
