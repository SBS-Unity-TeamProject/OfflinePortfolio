using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "MonsterExp", menuName = "MonsterStatus/Exp", order = 2)]
public class MonsterExp : ScriptableObject
{
    //아래로 갈수록 강해짐
    public int a = 1;
    public int FlyingEye = 3;
    public int Goblin = 4;
    public int Mushroom = 5;
    public int Skeleton = 5;
    public int EvilWizard1 = 15;
    public int EvilWizard2 = 18;
    public int EvilWizard3 = 25;
    public int HeroKnight1 = 35;
    public int HeroKnight2 = 50;
    public int MartialHero = 55;
}
