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
    [SerializeField] Transform arrow;
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
        //arrow = GameManager.Instance.transform;
        //arrow.parent = transform;
        arrow.localPosition = Vector3.zero;
        arrow.localRotation = Quaternion.identity;
        Vector3 rotVec = Vector3.forward * 360 / count;
        arrow.Rotate(rotVec);
        arrow.Translate(arrow.up * 1.5f, Space.World);
        if(!scanner.nearestTarget)
        {
            //arrow.position = transform.position;
            return;
        }
        Vector3 targetPos = scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;
        arrow.position = transform.position;
        arrow.rotation = Quaternion.FromToRotation(Vector3.up, dir);

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
