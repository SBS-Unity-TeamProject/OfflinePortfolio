using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class WeaponLauncher : MonoBehaviour
{
    [SerializeField] PlayerStates playerStates;
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
        //���� �ð��Ŀ� �߻�
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

        float valuex = scanner.nearestTarget.position.x;
        float valuey = scanner.nearestTarget.position.y;
        projectile.transform.localScale = new Vector2
        {
            x = originScale.x * valuex,
            y = originScale.y * valuey,
        };

    }
}
