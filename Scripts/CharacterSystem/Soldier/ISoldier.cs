using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain,
    Captive
}
public abstract class ISoldier : ICharacter
{
    protected SoldierFSMSystem mFSMSystem;
    public ISoldier() : base() { MakeFSM(); }
    public override void UpdateFsmAI(List<ICharacter> target)
    {
        if (mIsKilled) return;
        mFSMSystem.currentState.Reason(target);
        mFSMSystem.currentState.Act(target);
    }
    public void MakeFSM()
    {
        mFSMSystem = new SoldierFSMSystem();
        SoldierIdleState idleState = new SoldierIdleState(mFSMSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mFSMSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mFSMSystem,this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);
        mFSMSystem.AddState(idleState, chaseState, attackState);
    }
    public override void UnderAttack(int damage)
    {
        if (mIsKilled) return;//角色死亡后不在进行攻击
        base.UnderAttack(damage);
        if (mAttr.currentHp <= 0)
        {
            PlayEffect();
            PlaySound();
            Killed();
        }
    }
    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifyObserver(SubjectType.SoldierKilled);
    }
    protected abstract void PlayEffect();
    protected abstract void PlaySound();

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitSoldier(this);
    }
}
