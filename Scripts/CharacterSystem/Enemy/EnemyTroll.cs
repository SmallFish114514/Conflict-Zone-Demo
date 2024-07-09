using System.Collections;
using UnityEngine;
public class EnemyTroll : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("TrollHitEffect");
    }
}