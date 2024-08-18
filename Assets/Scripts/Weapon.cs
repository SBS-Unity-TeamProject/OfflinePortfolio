using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Weapon : MonoBehaviour
{
    public float damage = 1;
    public int count = 1;
    public float rate = 0.3f;
    public float speed = 10f;
    public Scanner scanner;
    public int Level = 1;
    public Arrow arrow;
    public Transform arrowpos;
    float timer;

    void Awake()
    {
        scanner = GetComponent<Scanner>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > rate)
        {
            timer = 0f;
            Fire();
        }
    }

    void Fire()
    {
        if(!scanner.nearestTarget)
        {
            //Tarrow.position = transform.position;
            return;
        }
        Vector3 targetPos = scanner.nearestTarget.position;
        Vector3 dir = targetPos - arrowpos.transform.position;
        dir = dir.normalized;
        //arrow.gameObject.transform.position = transform.position * speed*Time.deltaTime;
        Instantiate(arrow,dir * speed * Time.deltaTime,Quaternion.FromToRotation(Vector3.up, dir));
        //arrow.transform.Translate(transform.position * speed * Time.deltaTime);
    }
}
