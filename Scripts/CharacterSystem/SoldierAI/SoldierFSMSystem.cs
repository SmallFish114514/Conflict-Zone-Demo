using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态管理
/// </summary>
public class SoldierFSMSystem 
{
    private List<ISoldierState> mStates = new List<ISoldierState>();
    private ISoldierState mCurrentState;
    public ISoldierState currentState { get { return mCurrentState; } }
    /// <summary>
    /// 获取多组状态
    /// </summary>
    /// <param name="states"></param>
    public void AddState(params ISoldierState[] states)
    {
        foreach (ISoldierState s in states)
        {
            AddState(s);
        }
    }
    /// <summary>
    /// 获取状态
    /// </summary>
    /// <param name="state"></param>
    public void AddState(ISoldierState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空"); return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState= state;
            return;
        }
        foreach(ISoldierState s in mStates)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("要添加的状态【" + s.stateID + "】已经添加了");
            }
        }
        mStates.Add(state);
    }
    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="stateID"></param>
    public void DeleteState(SoldierStateID stateID)
    {
        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("要删除的状态ID为空" + stateID);return;
        }
        foreach(ISoldierState s in mStates)
        {
            if (stateID == s.stateID)
            {
                mStates.Remove(s); return;
            }
        }
        Debug.LogError("要删除的StateID不存在在集合中");return;
    }
    /// <summary>
    /// 执行转换
    /// </summary>
    /// <param name="trans"></param>
    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空："+trans); return;
        }
        SoldierStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == SoldierStateID.NullState)
        {
            Debug.LogError("在转换条件下【" + trans + "】，没有对应的");return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }
    }
}