using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "PlayerStates", menuName = "Player/Status", order = 1)]
public class PlayerStates : ScriptableObject
{
    public int Strength = 10;
    public int MoveSpeed = 5;
    public int MaxHealth = 100;
    public int Armor = 0;
    public float Range = 2f;
    public float AttackSpeed = 1f;
}
