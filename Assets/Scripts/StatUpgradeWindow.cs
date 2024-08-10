using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUpgradeWindow : MonoBehaviour
{
    [SerializeField] PlayerStates playerStates;
    [SerializeField] PlayerController controller;
    [SerializeField] TextMeshProUGUI MS;
    [SerializeField] TextMeshProUGUI STR;
    [SerializeField] TextMeshProUGUI MHP;
    [SerializeField] TextMeshProUGUI AR;
    [SerializeField] TextMeshProUGUI AS;
    [SerializeField] TextMeshProUGUI HPR;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MS.text = "Move Speed : " + (controller.defaultStatUP / 5);
        STR.text = "Strength : " + (controller.defaultStatUP * 5);
        MHP.text = "Max Health : " + (controller.defaultStatUP * 30);
        AR.text = "Attack Range" + (controller.defaultStatUP / 10);
        AS.text = "Attack Speed : " + (controller.defaultStatUP / 10);
        HPR.text = "HealthRecovery";     
    }

    public void MSClick()
    {
        controller.StatUPWindow.SetActive(false);
    }

    public void STRClick()
    {
        controller.StatUPWindow.SetActive(false);

    }
    public void MHPClick()
    {
        controller.StatUPWindow.SetActive(false);

    }
    public void ARClick()
    {
        controller.StatUPWindow.SetActive(false);

    }
    public void ASClick()
    {
        controller.StatUPWindow.SetActive(false);

    }
    public void HPRClick()
    {
        controller.StatUPWindow.SetActive(false);
        controller.currentHealth = playerStates.MaxHealth;
    }
}
