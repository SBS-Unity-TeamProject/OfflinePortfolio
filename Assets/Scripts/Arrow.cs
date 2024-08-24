using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] PlayerStates playerStates;
    public int damage = 10;
    [SerializeField] Scanner scanner;
    //public WeaponLauncher weaponLauncher;
    //public Transform arrowpos;
    //public Vector2 dir = Vector2.zero;
    //public Vector2 moveSpeed = new Vector2(1f, 1f);
    //public Vector2 knockback = Vector2.zero;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerStates = GetComponent<PlayerStates>();   
    }


    Damageable damageable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            //Vector2 deliveredKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, -knockback.y);
            //TODO : ���� �����ϴ� ĳ���Ͱ� �ٶ󺸴� �������� vector2 ����
            if (collision.CompareTag("Enemy"))
            {
                bool gotHit = damageable.GetHit(damage);
                if(gotHit)
                {
                    Destroy(this.gameObject);
                }
            }
        }

    }

}
