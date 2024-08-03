using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public PlayerStates playerStates;
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
        hp.text = "MAX HEALTH :      " + playerStates.MaxHealth;
        str.text = "STRENGTH :         " + playerStates.Strength;
        movespeed.text = "MOVE SPEED :     " + playerStates.MoveSpeed;
        armor.text = "ARMOR :               " + playerStates.Armor;

    }
    public void Exit()
    {
        statusPanel.SetActive(false);
    }
}
