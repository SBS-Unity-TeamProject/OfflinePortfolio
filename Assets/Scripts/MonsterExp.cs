using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "MonsterExp", menuName = "MonsterStatus/Exp", order = 2)]
public class MonsterExp : ScriptableObject
{
    //¾Æ·¡·Î °¥¼ö·Ï °­ÇØÁü
    public int a = 1;
    public int FlyingEye = 3; //º¸½º ¸÷
    public int Goblin = 4;
    public int Mushroom = 5;
    public int Skeleton = 5;
    public int EvilWizard1 = 15;
    public int EvilWizard2 = 18; //º¸½º ¸÷
    public int EvilWizard3 = 25;
    public int HeroKnight1 = 35;
    public int HeroKnight2 = 50;
    public int MartialHero = 55; // º¸½º ¸÷
}
