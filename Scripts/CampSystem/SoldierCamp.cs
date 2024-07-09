using System.Collections;
using UnityEngine;
public class SoldierCamp : ICamp
{
    const int MAX_Lv= 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;

    public SoldierCamp(GameObject gameObject, string name, string IconSprite, Vector3 Pos, SoldierType soldierType,float trainTime, int Lv=1, WeaponType weaponType=WeaponType.Gun)
        :base(gameObject,name,IconSprite,Pos,soldierType,trainTime)
    {
        mLv = Lv;
        mWeaponType = weaponType;
        energyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override int level
    {
        get { return mLv; }
    }

    public override WeaponType weaponType
    {
        get { return mWeaponType; }
    }

    public override int energyCostWeaponUpgrade
    {
        get
        {
            if (mWeaponType+1==WeaponType.Max)
                return -1;
            else
                return mEnergyCostWeaponUpgrade;
        }
    }

    public override int energyCostCampUpgrade
    {
        get
        {
            if (mLv == MAX_Lv)
                return -1;
            else
                return mEnergyCostCampUpgrade;
        }
    }
    public override int energyCostSoldierUpgrade
    {
        get
        {
            return mEnergyCostTrain;
        }
    }

    /// <summary>
    /// 添加命令
    /// </summary>
    public override void Train()
    {
        TrainSoldierCommand cmd = new TrainSoldierCommand(mPos, mWeaponType, mLv, mSoldierType);
        mCommands.Add(cmd);
        //Debug.Log(cmd + "SoldierCamp");
    }

    public override void UpdateEnergyCost()
    {
        mEnergyCostCampUpgrade = energyCostStrategy.GetCampEnergyStrategy(mSoldierType, mLv);
        mEnergyCostWeaponUpgrade = energyCostStrategy.GetWeaponEnergyStrategy(mWeaponType);
        mEnergyCostTrain = energyCostStrategy.GetSoldierEnergyStrategy(mSoldierType, mLv);
    }

    public override void UpgradeCamp()
    {
        mLv++;
        UpdateEnergyCost();
    }

    public override void UpgradeWeapon()
    {
        mWeaponType = mWeaponType + 1;
        UpdateEnergyCost();
    }
}
