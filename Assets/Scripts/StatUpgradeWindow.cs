using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatUpgradeWindow : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] PlayerStates playerStates;
    [SerializeField] PlayerController controller;
    [SerializeField] TextMeshProUGUI MS;
    [SerializeField] TextMeshProUGUI STR;
    [SerializeField] TextMeshProUGUI MHP;
    [SerializeField] TextMeshProUGUI AR;
    [SerializeField] TextMeshProUGUI AS;
    [SerializeField] TextMeshProUGUI HPR;
    [SerializeField] GameObject MS2;
    [SerializeField] GameObject STR2;
    [SerializeField] GameObject MHP2;
    [SerializeField] GameObject AR2;
    [SerializeField] GameObject AS2;
    [SerializeField] GameObject HPR2;
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        MS.text = "Move Speed : " + (controller.defaultStatUP / 5) + "+";
        STR.text = "Strength : " + (controller.defaultStatUP * 5) + "+";
        MHP.text = "Max Health : " + (controller.defaultStatUP * 30) + "+";
        AR.text = "Attack Range" + (controller.defaultStatUP / 10) + "+";
        AS.text = "Attack Speed : " + (controller.defaultStatUP / 10) + "+";
        HPR.text = "HealthRecovery";
        if (Panel)
        {
            switch (3)
            {
                case 1:
                    MS2.SetActive(true); break;
                case 2:
                    STR2.SetActive(true); break;
                case 3:
                    MHP2.SetActive(true); break;
                case 4:
                    AR2.SetActive(true); break;
                case 5:
                    AS2.SetActive(true); break;
                case 6:
                    HPR2.SetActive(true); break;
            }
        }
    }
    
    public void MSClick()
    {
        controller.StatUPWindow.SetActive(false);
        playerStates.MoveSpeed += (controller.defaultStatUP/5);
    }

    public void STRClick()
    {
        controller.StatUPWindow.SetActive(false);
        playerStates.Strength += (controller.defaultStatUP);
    }
    public void MHPClick()
    {
        controller.StatUPWindow.SetActive(false);
        playerStates.MaxHealth += (controller.defaultStatUP * 30);

    }
    public void ARClick()
    {
        controller.StatUPWindow.SetActive(false);
        playerStates.Range += (controller.defaultStatUP / 10);

    }
    public void ASClick()
    {
        controller.StatUPWindow.SetActive(false);
        playerStates.AttackSpeed += (controller.defaultStatUP/10);

    }
    public void HPRClick()
    {
        controller.StatUPWindow.SetActive(false);
        controller.currentHealth = (int)playerStates.MaxHealth;
    }
}
