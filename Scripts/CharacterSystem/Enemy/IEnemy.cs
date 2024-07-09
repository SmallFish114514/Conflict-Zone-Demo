using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}
public abstract class  IEnemy : ICharacter
{
    protected EnemyFSMSystem mFSMSystem;

    public IEnemy()
    {
        MakeFsm();
    }
    public override void UpdateFsmAI(List<ICharacter> target)
    {
        if (mIsKilled) return;//如果被消灭。则停止更新状态机
        mFSMSystem.currentState.Reason(target);
        mFSMSystem.currentState.Act(target);
    }
    public void MakeFsm()
    {
        mFSMSystem = new EnemyFSMSystem();
        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem,this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);
        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);
        mFSMSystem.AddState(chaseState, attackState);
    }
    public override void UnderAttack(int damage)
    {
        if (mIsKilled) return;//角色死亡后不在进行攻击
        base.UnderAttack(damage);
        PlayEffect();
        if (mAttr.currentHp <= 0)
        {
            Killed();
        }
    }
    public abstract void PlayEffect();
    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifyObserver(SubjectType.EnemyKilled);
        //Debug.Log("Killed");
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }
}
