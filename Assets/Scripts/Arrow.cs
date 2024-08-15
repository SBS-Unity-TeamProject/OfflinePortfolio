using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage = 3;
    public int penetrate = 3;
    public float speed = 0.3f;

    void Update()
    {
    }

    public void Init(float damage)
    {
        this.damage = damage;
    }

}
