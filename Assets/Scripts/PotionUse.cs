using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUse : MonoBehaviour
{
    [SerializeField] private int HealthPotion = 10;
    [SerializeField] private int ManaPotion = 10;
    [SerializeField] private int MaxPotion = 10;
    private PotionUse _potionUse;

    void Start()
    {
        _potionUse = GetComponentInParent<PotionUse>();
        HealthPotion = MaxPotion;
        ManaPotion = MaxPotion;
    }
    void Update()
    {
        Potion();
    }

    void Potion()
    {
        if(Input.GetButtonDown("Slot"))
        {
            if (HealthPotion <= 0) return;
            HealthPotion--;
        }
        if(Input.GetButtonDown("Slot (1)"))
        {
            if (ManaPotion <= 0) return;
            ManaPotion--;
        }
    }
}
