using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable)
        {
            damageable.GetHit(10);
        }
    }
}
