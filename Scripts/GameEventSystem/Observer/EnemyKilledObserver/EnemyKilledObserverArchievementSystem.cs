using System.Collections;
using UnityEngine;
public class EnemyKilledObserverArchievementSystem : IGameEventObserver
{    
    private ArchievementSystem mArchievementSystem;
    public EnemyKilledObserverArchievementSystem (ArchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        //mSubject = subject as EnemyKilledSubject;        
    }
    public override void Update()
    {
        mArchievementSystem.AddEnemyKilledCount();
    }
}
