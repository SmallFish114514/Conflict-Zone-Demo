using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledObserverArchievementSystem : IGameEventObserver
{
    private SoldierKilledSubject mSubject;
    private ArchievementSystem mArchievementSystem;
    public SoldierKilledObserverArchievementSystem(ArchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        
    }

    public override void Update()
    {
        mArchievementSystem.AddSoldierKilledCount();
    }
}
