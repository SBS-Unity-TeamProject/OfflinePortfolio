using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] Slider expBar;
    [SerializeField] PlayerController playerController;
    void Start()
    {
        expBar.maxValue = playerController.expForLevelUpp;
    }

    // Update is called once per frame
    void Update()
    {
        expBar.value = playerController.currentExp;
    }
}
