using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Weapon : MonoBehaviour
{
    public float damage = 1;
    public int count = 1;
    public float speed = 0.3f;
    public Scanner scanner;
    public int Level = 1;
    public GameObject Garrow;
    [SerializeField] Transform Tarrow;
    Rigidbody2D rigid;
    float timer;

    void Awake()
    {
        scanner = GetComponent<Scanner>();
        rigid = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > speed)
        {
            timer = 0f;
            Fire();
        }
        //if(Input.GetButtonDown("L"))
        //{
        //    LevelUp(20, 5);
        //}
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;
    }

    void Fire()
    {
        if(!scanner.nearestTarget)
        {
            //arrow.position = transform.position;
            return;
        }
        //arrow = GameManager.Instance.transform;
        //arrow.parent = transform;
        Tarrow.localPosition = Vector3.zero;
        Tarrow.localRotation = Quaternion.identity;
        Vector3 rotVec = Vector3.forward * 360 / count;
        Tarrow.Rotate(rotVec);
        Tarrow.Translate(Tarrow.up * speed*Time.deltaTime, Space.World);
        Vector3 targetPos = scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized * speed * Time.deltaTime;
        Tarrow.position = transform.position;
        Tarrow.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Instantiate(Garrow,Tarrow);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Enemy"))
        {
            return;
        }
        rigid.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
