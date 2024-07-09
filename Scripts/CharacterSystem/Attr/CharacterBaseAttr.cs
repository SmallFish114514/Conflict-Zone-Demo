using System.Collections;
using UnityEngine;
/// <summary>
/// 享元模式
/// 需要共享的基础属性
/// </summary>
public  class CharacterBaseAttr
{
    protected string mName;
    protected int mMaxHp;
    protected float mSpeed;
    protected string mIconSprite;//获取角色头像
    protected string mPrefabName;
    protected float mCritRate;//0-1暴击率

    public CharacterBaseAttr(string Name,int MaxHp,float Speed,string IconSprite,string PrefabName,float CritRate)
    {
        mName = Name;
        mMaxHp = MaxHp;
        mSpeed = Speed;
        mIconSprite = IconSprite;
        mPrefabName = PrefabName;
        mCritRate = CritRate;
    }
    public string Name { get { return mName; } }
    public int MaxHp { get { return mMaxHp; } }
    public float Speed { get { return mSpeed; } }
    public string IconSprite { get { return mIconSprite; } }
    public string PrefabName { get { return mPrefabName; } }
    public float CritRate { get { return mCritRate; } }
}
