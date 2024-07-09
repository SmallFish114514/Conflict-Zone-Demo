using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoldierAttackState : ISoldierState
{
    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mAttackTimer = mAttackTime;//重置时间
        mStateID = SoldierStateID.Attack; 
    }
    private float mAttackTime = 1;
    private float mAttackTimer = 1;
    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;
            mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mAttackTimer = 0;
        }
    }
    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFsm.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
        if (distance > mCharacter.AtkRange)
        {
            //相距超过攻击范围转换为追击状态
            mFsm.PerformTransition(SoldierTransition.SeeEnemy);
        }        
    }
}
