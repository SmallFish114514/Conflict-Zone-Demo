using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态管理
/// </summary>
public class EnemyFSMSystem
{
    private List<IEnemyState> mStates = new List<IEnemyState>();
    private IEnemyState mCurrentState;
    public IEnemyState currentState { get { return mCurrentState; } }
    /// <summary>
    /// 获取多组状态
    /// </summary>
    /// <param name="states"></param>
    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState s in states)
        {
            AddState(s);
        }
    }
    /// <summary>
    /// 获取状态
    /// </summary>
    /// <param name="state"></param>
    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空"); return;
        }
        if (mStates.Count == 0)
        {//默认状态
            mStates.Add(state);
            mCurrentState = state;
            mCurrentState.DoBeforeEntering();
            return;
        }
        foreach (IEnemyState s in mStates)
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
    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("要删除的状态ID为空" + stateID); return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (stateID == s.stateID)
            {
                mStates.Remove(s); return;
            }
        }
        Debug.LogError("要删除的StateID不存在在集合中"); return;
    }
    /// <summary>
    /// 执行转换
    /// </summary>
    /// <param name="trans"></param>
    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空：" + trans); return;
        }
        EnemyStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("在转换条件下【" + trans + "】，没有对应的"); return;
        }
        foreach (IEnemyState s in mStates)
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
