using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // 공격 쿨타임
    [SerializeField] private float elapsedTimer = 0.5f;
    // 현재 타이머 변수
    private float timer = 0;
    // 현재 공격 가능한지 여부
    private bool canAttack = true;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable)
        {
            damageable.GetHit(120);
        }
    }

}
