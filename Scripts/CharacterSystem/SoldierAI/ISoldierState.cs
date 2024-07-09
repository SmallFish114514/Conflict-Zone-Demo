using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 转换条件
/// </summary>
public enum SoldierTransition
{
    NullTransition=0,
    CanAttack,
    SeeEnemy,
    NoEnemy
}
/// <summary>
/// 士兵状态ID
/// </summary>
public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack
}
/// <summary>
/// 战士的抽象状态接口
/// </summary>
public abstract class ISoldierState
{
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mStateID;
    protected ICharacter mCharacter;
    protected SoldierFSMSystem mFsm;
    public ISoldierState(SoldierFSMSystem fsm,ICharacter character)
    {
        mFsm = fsm;
        mCharacter = character;
    }
    /// <summary>
    /// 外界获取SoldierStateID
    /// </summary>
    public SoldierStateID stateID { get { return mStateID; } }
    /// <summary>
    /// 添加转换条件以及状态
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="id"></param>
    public void AddTransition(SoldierTransition trans,SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierTranitionError:trans不能为空"); return;
        }
        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierStateIDError:id状态ID不能为空");return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierTransitionError:"+trans+"已经添加上了");return;
        }
        mMap.Add(trans, id);
    }
    /// <summary>
    /// 删除转换条件以及状态
    /// </summary>
    /// <param name="trans"></param>
    public void DeleteTransition(SoldierTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("删除转换条件时，" + trans + "转换条件不存在");return;
        }
        mMap.Remove(trans);
    }
    /// <summary>
    /// 根据转换条件进行状态转换
    /// 返回状态ID
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public SoldierStateID GetOutPutState(SoldierTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            return SoldierStateID.NullState;
        }
        return mMap[trans];
    }
    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }
    /// <summary>
    /// 判断当前状态是否需要转换到其他条件
    /// </summary>
    public abstract void Reason(List<ICharacter> targets);
    /// <summary>
    /// 当前状态下具体执行的行为
    /// </summary>
    public abstract void Act(List<ICharacter> targets);
}
