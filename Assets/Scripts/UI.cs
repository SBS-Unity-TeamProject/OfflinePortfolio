using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public enum InfoType {  Exp, Level, Kill, Time, Health};
    public InfoType type;

    Text myText;
    Slider mySlider;
    PlayerStates playerStates;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
        playerStates = GetComponent<PlayerStates>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                //float CurExp = 
               // float MaxExp =
                break;
            case InfoType.Level:

                break;
            case InfoType.Kill:

                break;
            case InfoType.Time:

                break;
            case InfoType.Health:

                break;
        }
    }
}
