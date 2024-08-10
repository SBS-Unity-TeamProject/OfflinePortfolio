using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage = 3;
    public int penetrate = 3;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage,int penetrate,Vector3 dir)
    {
        this.damage = damage;
        this.penetrate = penetrate;

        if(penetrate > -1)
        {
            rigid.velocity = dir*15f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || penetrate == -1)
            return;

        penetrate--;

        if(penetrate == -1)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
