using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色数值属性
/// </summary>
public class ICharacterAttr
{
    protected CharacterBaseAttr mBaseAttr;//基础属性
    protected int mCurrentHP;
    protected int mLevel;//等级
    
    protected int mDamDescValue;//等级提升抵御的伤害
    //增加的血量  抵御的伤害  暴击率
    protected IAttrStrategy mStrategy;//策略接口
    public ICharacterAttr(IAttrStrategy strategy,int level,CharacterBaseAttr baseAttr)
    {
        mBaseAttr = baseAttr;
        mStrategy = strategy;        
        mLevel = level;        
        mDamDescValue = strategy.GetDamageDescVal(mLevel);
        mCurrentHP = mBaseAttr.MaxHp + strategy.GetExtralHPVal(mLevel);
    }
    public IAttrStrategy AttrStrategy { get { return mStrategy; } }
    public CharacterBaseAttr BaseAttr { get { return mBaseAttr; } }
    public int critValue { get { return mStrategy.GetCrit(mBaseAttr.CritRate); } }
    public int DamDescValue { get { return mDamDescValue; } }
    public int currentHp { get { return mCurrentHP; } }
    /// <summary>
    /// 伤害数值判定
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        damage -= mDamDescValue;
        if (damage < 5)
            damage = 5;
        mCurrentHP -= damage;
    }
}
