using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] public GameObject inventoryPanel_I;
    [SerializeField] public GameObject inventoryPanel_K;
    bool activeInventory_I = false;
    bool activeInventory_K = false;

    private void Start()
    {
        inventoryPanel_I.SetActive(activeInventory_I);
        inventoryPanel_K.SetActive(activeInventory_K);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            activeInventory_I = !activeInventory_I;
            inventoryPanel_I.SetActive(activeInventory_I);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            activeInventory_K = !activeInventory_K;
            inventoryPanel_K.SetActive(activeInventory_K);
        }
    }
}
