using System.Collections;
using UnityEngine;
public class SoldierRookie : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("RookieDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("RookieDeath");
    }
}