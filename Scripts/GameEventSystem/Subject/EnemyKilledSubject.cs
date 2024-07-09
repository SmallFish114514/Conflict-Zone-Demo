using System.Collections;
using UnityEngine;
public class EnemyKilledSubject : IGameEventSubject
{
    private int mKilledCount=0;
    public int KilledCount { get { return mKilledCount; } }
    public override void NotifyObserver()
    {
        mKilledCount++;
        //Debug.Log("EnemyKilledSubject"+mKilledCount);
        base.NotifyObserver();
    }

}
