using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController controller;
    [SerializeField] GameObject exp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ExpUp();
    }
    public void ExpUp()
    {
        Debug.Log("exp");
        //controller.exp++;
        Destroy(exp);
    }
}
