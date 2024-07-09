using System.Collections;
using UnityEngine;
public class SoldierSergeant : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("SergeantDeadEffect");
    }
    protected override void PlaySound()
    {
        DoPlaySound("SergeantDeath");
    }
}