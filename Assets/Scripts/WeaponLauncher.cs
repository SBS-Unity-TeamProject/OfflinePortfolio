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
        //일정 시간후에 발사
        timer += Time.deltaTime;
        if(timer > rate)
        {
            timer = 0f;
            if (!scanner.nearestTarget)
            {
                return;
            }
            //arrow.transform.position = arrow.transform.position * speed*Time.deltaTime;
            //Instantiate(arrow,dir * speed * Time.deltaTime,Quaternion.FromToRotation(Vector3.up, dir));
            //arrow.transform.Translate(arrow.transform.position * speed * Time.deltaTime);
            //디버깅 해서 무슨값인지 찾기
            Vector3 targetPos = scanner.nearestTarget.position;
            targetPos -= arrowpos.parent.position;
            Vector3 dir = targetPos - arrowpos.position;
            dir = dir.normalized;
            Instantiate(arrow, arrowpos.transform.position, arrowpos.transform.rotation);
        }
        arrow.transform.TransformVector(arrow.transform.position*Time.deltaTime);
    }

}
