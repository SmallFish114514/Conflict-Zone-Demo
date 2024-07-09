using System.Collections;
using UnityEngine;
public class EnemyKilledObserverStageSystem : IGameEventObserver
{
    private EnemyKilledSubject mSubject;
    private StageSystem mStageSystem;
    public EnemyKilledObserverStageSystem(StageSystem stageSystem)
    {
        mStageSystem = stageSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject = subject as EnemyKilledSubject;
    }
    public override void Update()
    {
        mStageSystem.EnemyCountOfKilled = mSubject.KilledCount;
        //Debug.Log("EnemyKilled" + mStageSystem.GetCountOfEnemyKilled());        
    }
}