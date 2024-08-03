using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI str;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI movespeed;
    [SerializeField] TextMeshProUGUI armor;
    [SerializeField] GameObject statusPanel;
    void Start()
    {
        statusPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            statusPanel.SetActive(true);
        }
        str.text = "STRENGTH :         0";
        hp.text = "MAX HEALTH :      0";
        movespeed.text = "MOVE SPEED :     0";
        armor.text = "ARMOR :               0";

    }
    public void Exit()
    {
        statusPanel.SetActive(false);
    }
}
