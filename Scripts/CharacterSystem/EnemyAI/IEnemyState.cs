using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 转换条件
/// </summary>
public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    LostSoldier
}
/// <summary>
/// 士兵状态ID
/// </summary>
public enum EnemyStateID
{
    NullState,    
    Chase,
    Attack
}
public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFsm;
    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        mFsm = fsm;
        mCharacter = character;
    }
    /// <summary>
    /// 外界获取EnemyStateID
    /// </summary>
    public EnemyStateID stateID { get { return mStateID; } }
    /// <summary>
    /// 添加转换条件以及状态
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="id"></param>
    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("EnemyTranitionError:trans不能为空"); return;
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyStateIDError:id状态ID不能为空"); return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("EnemyTransitionError:" + trans + "已经添加上了"); return;
        }
        mMap.Add(trans, id);
    }
    /// <summary>
    /// 删除转换条件以及状态
    /// </summary>
    /// <param name="trans"></param>
    public void DeleteTransition(EnemyTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("删除转换条件时，" + trans + "转换条件不存在"); return;
        }
        mMap.Remove(trans);
    }
    /// <summary>
    /// 根据转换条件进行状态转换
    /// 返回状态ID
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public EnemyStateID GetOutPutState(EnemyTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            return EnemyStateID.NullState;
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
