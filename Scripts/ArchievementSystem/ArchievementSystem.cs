using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 成就系统
/// </summary>
public class ArchievementSystem : IGameSystem
{
    private int mEnemyKilledCount=0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLv = 1;
    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(SubjectType.EnemyKilled, new EnemyKilledObserverArchievementSystem(this));
        mFacade.RegisterObserver(SubjectType.SoldierKilled, new SoldierKilledObserverArchievementSystem(this));
        mFacade.RegisterObserver(SubjectType.NewStage, new StageObserverArchievement(this));
    }
    public void AddEnemyKilledCount(int number=1)
    {
        mEnemyKilledCount += number;
        Debug.Log("EnemyKilledCount" + number);
    }
    public void AddSoldierKilledCount(int number=1)
    {
        mSoldierKilledCount += number;
        Debug.Log("SoldierKilledCount" + number);
    }
    /// <summary>
    /// 关卡成就为最大关卡数
    /// </summary>
    /// <param name="stageLv"></param>
    public void AddMaxStageLv(int stageLv)
    {
        if (stageLv > mMaxStageLv)
        {
            mMaxStageLv = stageLv;
        }
        Debug.Log("MaxStageLv" + mMaxStageLv);
    }
    /// <summary>
    /// 创建备忘录
    /// </summary>
    public AchievementSystemMemento CreateMemento()
    {
        //PlayerPrefs.SetInt("SoldierKilledCount", mSoldierKilledCount);
        //PlayerPrefs.SetInt("EnemyKilledCount", mEnemyKilledCount);
        //PlayerPrefs.SetInt("MaxStageLv", mMaxStageLv);

        AchievementSystemMemento memento = new AchievementSystemMemento();
        memento.EnemyKilledCount = mEnemyKilledCount;
        memento.SoldierKilledCount = mSoldierKilledCount;
        memento.MaxStageLv = mMaxStageLv;
        return memento;
    }
    /// <summary>
    /// 取出备忘录
    /// </summary>
    public void SetMemento(AchievementSystemMemento memento)
    {
        //mSoldierKilledCount= PlayerPrefs.GetInt("SoldierKilledCount");
        //mEnemyKilledCount = PlayerPrefs.GetInt("EnemyKileedCount");
        //mMaxStageLv = PlayerPrefs.GetInt("MaxStageLv");
        mSoldierKilledCount = memento.SoldierKilledCount;
        mEnemyKilledCount = memento.EnemyKilledCount;
        mMaxStageLv = memento.MaxStageLv;
    }
}
