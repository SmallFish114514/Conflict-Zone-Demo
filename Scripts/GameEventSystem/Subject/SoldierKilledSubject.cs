using System.Collections;
using UnityEngine;
/// <summary>
/// 战士被击杀的主题
/// </summary>
public class SoldierKilledSubject : IGameEventSubject
{
    private int mKilledCount;
    public int KilledCount
    {
        get { return mKilledCount; }
    }
    public override void NotifyObserver()
    {
        mKilledCount++;
        //Debug.Log(mKilledCount);
        base.NotifyObserver();
    }
}