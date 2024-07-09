using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBaseAttr
{
    protected int mAtk;
    protected float mAtkRange;
    protected string mName;
    protected string mAssetName;
    public WeaponBaseAttr(int Atk,float AtkRange,string Name,string AssetName)
    {
        mAtk = Atk;
        mAtkRange = AtkRange;
        mName = Name;
        mAssetName = AssetName;
    }
    public int Atk { get { return mAtk; } }
    public float AtkRange { get { return mAtkRange; } }
    public string Name { get { return mName; } }
    public string AssetName { get { return mAssetName; } }
}
