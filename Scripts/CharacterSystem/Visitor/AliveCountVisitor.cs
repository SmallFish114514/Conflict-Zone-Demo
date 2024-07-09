using System.Collections;
using UnityEngine;
public class AliveCountVisitor : ICharacterVisitor
{
    public int enemyAliveCount { get; private set; }
    public int soldierAliveCount { get; private set; }
    public void Reset()
    {
        enemyAliveCount = 0;
        soldierAliveCount = 0;
    }
    public override void VisitEnemy(IEnemy enemy)
    {
        if(enemy.IsKilled==false)
        enemyAliveCount += 1;
    }
    public override void VisitSoldier(ISoldier soldier)
    {
        if (soldier.IsKilled == false)
            soldierAliveCount += 1;
    }
}
