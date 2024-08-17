using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 10;
    public Scanner scanner;
    public Vector2 moveSpeed = new Vector2(1, 0);
    //public Vector2 knockback = Vector2.zero;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y * transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            //Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, -knockback.y);
            //TODO : 현재 공격하는 캐릭터가 바라보는 방향으로 vector2 설정
            bool gotHit = damageable.GetHit(damage);
            if (collision.CompareTag("Enemy") && gotHit)
            {
                Destroy(this.gameObject);
            }
        }

    }

}
