using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoldierChaseState : ISoldierState
{
    /// <summary>
    /// 获取fsmSystem的引用
    /// </summary>
    /// <param name="fsm"></param>
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c) { mStateID = SoldierStateID.Chase; }
    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFsm.PerformTransition(SoldierTransition.NoEnemy); return;
        }
        float distance = Vector3.Distance(targets[0].Position, mCharacter.Position);
        //Debug.Log("SoldierChaseState" + targets);
        if (distance <= mCharacter.AtkRange)
        {
            mFsm.PerformTransition(SoldierTransition.CanAttack);
        }
    }
}
