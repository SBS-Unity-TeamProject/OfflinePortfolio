using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // ���� ��Ÿ��
    [SerializeField] private float elapsedTimer = 0.5f;
    // ���� Ÿ�̸� ����
    private float timer = 0;
    // ���� ���� �������� ����
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
