using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem fsm,ICharacter c) : base(fsm,c) { mStateID = SoldierStateID.Idle; }
    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnim("stand");
    }
    /// <summary>
    /// 判断是否进行转换
    /// </summary>
    /// <param name="targets"></param>
    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            //执行转换
            mFsm.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}