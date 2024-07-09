using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttackState : IEnemyState
{
    public EnemyAttackState(EnemyFSMSystem enemyFSM, ICharacter character) : base(enemyFSM, character)
    {
        mStateID = EnemyStateID.Attack;
        mAttackTimer = mAttackTime;//重置时间 更改时间只需更改mAttackTime，不需两个都更改
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
            mFsm.PerformTransition(EnemyTransition.LostSoldier);
        }
        else
        {
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if (distance > mCharacter.AtkRange)
                mFsm.PerformTransition(EnemyTransition.LostSoldier);            
        }
    }
}
