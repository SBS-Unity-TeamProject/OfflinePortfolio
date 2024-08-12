using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Weapon : MonoBehaviour
{
    public float damage = 1;
    public int count = 1;
    public float speed = 0.3f;
    public Scanner scanner;
    public int Level = 1;
    public GameObject Garrow;
    [SerializeField] Transform Tarrow;
    float timer;

    void Awake()
    {
        scanner = GetComponent<Scanner>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > speed)
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
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;
        Tarrow.position = transform.position;
        Tarrow.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Instantiate(Garrow,Tarrow);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Enemy"))
        {
            return;
        }
        Garrow.SetActive(false);
    }
}
