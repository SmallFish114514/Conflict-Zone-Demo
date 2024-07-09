using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SubjectType
{
    Null,
    SoldierKilled,
    EnemyKilled,
    NewStage
}
public class GameEventSystem : IGameSystem
{
    private Dictionary<SubjectType, IGameEventSubject> mGameEvents = new Dictionary<SubjectType, IGameEventSubject>();
    public override void Init()
    {
        base.Init();        
    }    
    public void RegisterObserver(SubjectType subjectType,IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEventSub(subjectType);
        if (sub == null) return;
        sub.RegisterObserver(observer);
        observer.SetSubject(sub);
    }
    public void RemoveObserver(SubjectType subjectType,IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEventSub(subjectType);
        if (sub == null) return;
        sub.RemoveObserver(observer);
        observer.SetSubject(null);
    }
    public void NotifyObserver(SubjectType subjectType)
    {
        IGameEventSubject sub = GetGameEventSub(subjectType);
        if (sub == null) return;
        sub.NotifyObserver();
    }
    public IGameEventSubject GetGameEventSub(SubjectType subjectType)
    {
        if (mGameEvents.ContainsKey(subjectType) == false)
        {
            switch (subjectType)
            {
                case SubjectType.SoldierKilled:
                    mGameEvents.Add(SubjectType.SoldierKilled, new SoldierKilledSubject());
                    break;
                case SubjectType.EnemyKilled:
                    mGameEvents.Add(SubjectType.EnemyKilled, new EnemyKilledSubject());
                    break;
                case SubjectType.NewStage:
                    mGameEvents.Add(SubjectType.NewStage, new NewStageSubject());
                    break;
                default:
                    Debug.LogError("没有对应事件类型" + subjectType + "的主题类");
                    break;
            }            
        }
        return mGameEvents[subjectType];
    }
}
