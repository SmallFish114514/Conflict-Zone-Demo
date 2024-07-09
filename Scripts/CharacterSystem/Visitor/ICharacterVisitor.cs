using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterVisitor
{
    public abstract void VisitEnemy(IEnemy enemy);
    public abstract void VisitSoldier(ISoldier soldier);
}
