using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "PlayerStates", menuName = "Player/Status", order = 1)]
public class PlayerStates : ScriptableObject
{
    public float Strength = 10;
    public float MoveSpeed = 5;
    public float MaxHealth = 100;
    public float Armor = 0;
    public float Range = 2f;
    public float AttackSpeed = 1f;

}
