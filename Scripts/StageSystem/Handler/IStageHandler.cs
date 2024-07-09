using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 责任链  主要用于敌人的生成
/// </summary>
public abstract class IStageHandler
{
    protected int mLv;//当前关卡
    protected IStageHandler mNextHandler;
    protected int mCountToFinshed;//通关所需消灭敌人的数量
    protected StageSystem mStageSystem;
    public IStageHandler SetNextHandler(IStageHandler nextHandler)
    {
        mNextHandler = nextHandler;
        return mNextHandler;
    }
    public IStageHandler (int Lv,int CountToFinshed,StageSystem stageSystem)
    {
        mLv = Lv;
        mCountToFinshed = CountToFinshed;
        mStageSystem = stageSystem;
    }
    public void Handle(int Lv)
    {
        if (mLv == Lv)
        {
            UpdateStage();
            CheckIsFinshed();
        }
        else
        {
            mNextHandler.Handle(Lv);
        }
    }
    /// <summary>
    /// 处理当前关卡的逻辑
    /// </summary>
    public virtual void UpdateStage() { }
    /// <summary>
    /// 检查当前关卡是否完成
    /// </summary>
    private void CheckIsFinshed()
    {
        if (mStageSystem.GetCountOfEnemyKilled() >= mCountToFinshed)
        {
            mStageSystem.EnterNextStage();
        }
    }
}
