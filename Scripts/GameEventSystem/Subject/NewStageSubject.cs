using System.Collections;
using UnityEngine;
/// <summary>
/// 进入新关卡的主题
/// </summary>
public class NewStageSubject : IGameEventSubject
{
    private int mStageCount = 1;
    public int StageCount
    {
        get { return mStageCount; }
    }
    public override void NotifyObserver()
    {
        mStageCount++;
        //Debug.Log("StageCount" + mStageCount);
        base.NotifyObserver();
    }
}
