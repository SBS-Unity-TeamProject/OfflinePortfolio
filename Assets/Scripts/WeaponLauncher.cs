using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class WeaponLauncher : MonoBehaviour
{
    public float damage = 1;
    public int count = 1;
    public float rate = 0.3f;
    public float speed = 1f;
    public Scanner scanner;
    public GameObject arrow;
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
        //Vector3 targetPos = scanner.nearestTarget.position;
        //Vector3 dir = targetPos - arrowpos.transform.position;
        //dir = dir.normalized;
        //arrow.transform.position = arrow.transform.position * speed*Time.deltaTime;
        //Instantiate(arrow,dir * speed * Time.deltaTime,Quaternion.FromToRotation(Vector3.up, dir));
        //arrow.transform.Translate(arrow.transform.position * speed * Time.deltaTime);
        GameObject projectile = Instantiate(arrow, arrowpos.position, arrow.transform.rotation);
        Vector3 originScale = projectile.transform.localScale;

        float valuex = transform.localScale.x > 0 ? 1 : -1;
        float valuey = transform.localScale.y > 0 ? 1 : -1;
        projectile.transform.localScale = new Vector3
        {
            x = originScale.x * valuex,
            y = originScale.y * valuey,
            z = originScale.z,
        };

    }
}
