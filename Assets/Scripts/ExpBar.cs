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

    }

    // Update is called once per frame
    void Update()
    {
        expBar.maxValue = playerController.expForLevelUpp;
        expBar.value = playerController.currentExp;
    }
}
