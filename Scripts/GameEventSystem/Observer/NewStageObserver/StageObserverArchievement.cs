using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObserverArchievement : IGameEventObserver
{
    private ArchievementSystem mArchievementSystem;
    private NewStageSubject mStageSubject;
    
    public StageObserverArchievement(ArchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mStageSubject = subject as NewStageSubject;
    }

    public override void Update()
    {
        mArchievementSystem.AddMaxStageLv(mStageSubject.StageCount);
    }
}
