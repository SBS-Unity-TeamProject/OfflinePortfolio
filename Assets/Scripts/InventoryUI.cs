using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject InventoryPanel;
    [SerializeField]
    GameObject
        ArmorPanel, RingsPanel, BowPanel;
    [SerializeField]
    Toggle
        ArmorToggle, RingsToggle, BowToggle;
    private void Start()
    {
        ArmorToggle.isOn = true;
        RingsToggle.isOn = false;
        BowToggle.isOn = false;

    }
    private void Update()
    {
        if (ArmorToggle.isOn)
        {
            RingsToggle.isOn = false;
            BowToggle.isOn = false;
        }
        else if (BowToggle.isOn)
        {
            ArmorToggle.isOn = false;
            RingsToggle.isOn = false;
        }
        else if (RingsToggle.isOn)
        {
            ArmorToggle.isOn = false;
            BowToggle .isOn = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!InventoryPanel)
            {
                InventoryPanel.SetActive(true);
            }
            else
            {
                InventoryPanel.SetActive(false);
            }
        }
    }
    public void ArmorToggleValueChanged()
    {
        if (ArmorToggle.isOn)
        {
            ArmorPanel.SetActive(true);
        }
        else
        {
            ArmorPanel.SetActive(false);
        }
    }
    public void RingsToggleValueChanged()
    {
        if (RingsToggle.isOn)
        {
            RingsPanel.SetActive(true);
        }
        else
        {
            RingsPanel.SetActive(false);
        }
    }
    public void BowsToggleValueChanged()
    {
        if (BowToggle.isOn)
        {
            BowPanel.SetActive(true);
        }
        else
        {
            BowPanel.SetActive(false);
        }
    }
}
