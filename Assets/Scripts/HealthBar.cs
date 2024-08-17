using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerStates playerStates;
    [SerializeField] PlayerController playerController;
    [SerializeField] Slider healthBar;
    void Start()
    {
        healthBar.maxValue = ((int)playerStates.MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerController.currentHealth;
    }
}
