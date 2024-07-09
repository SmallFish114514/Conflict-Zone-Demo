using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyChaseState : IEnemyState
{
    public EnemyChaseState (EnemyFSMSystem enemyFSM,ICharacter character) : base(enemyFSM, character)
    {
        mStateID = EnemyStateID.Chase;
    }
    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {            
            mCharacter.MoveTo(targets[0].Position);
            //Debug.Log(targets[0]);
        }
        else
        {
            mCharacter.MoveTo(mEnemyTargetPos);
            //Debug.Log(mEnemyTargetPos);
        }
    }
    private Vector3 mEnemyTargetPos;
    public override void DoBeforeEntering()
    {
        mEnemyTargetPos = GameFacade.Instance.GetEnemyTargetPos();
    }
    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        { 
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if(distance<=mCharacter.AtkRange)
            mFsm.PerformTransition(EnemyTransition.CanAttack);
        }
    }
}
