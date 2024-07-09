using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CaptiveCamp : ICamp
//{    
//    private WeaponType mWeaponType = WeaponType.Gun;
//    private EnemyType mEnemyType;

//    public CaptiveCamp(GameObject gameObject, string name, string IconSprite, Vector3 Pos, EnemyType enemyType, float trainTime)
//        : base(gameObject, name, IconSprite, Pos, SoldierType.Captive, trainTime)
//    {
//        mEnemyType = enemyType;
//        energyCostStrategy = new SoldierEnergyCostStrategy();
//        UpdateEnergyCost();
//    }
//    public override int level
//    {
//        get { return 1; }
//    }

//    public override WeaponType weaponType
//    {
//        get { return mWeaponType; }
//    }

//    public override int energyCostWeaponUpgrade
//    {
//        get { return 0; }
//    }

//    public override int energyCostCampUpgrade
//    {
//        get { return 0; }
//    }

//    public override int energyCostSoldierUpgrade
//    {
//        get { return mEnergyCostTrain; }
//    }

//    public override void Train()
//    {
//        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType, mWeaponType, mPos);
//        mCommands.Add(cmd);
//    }

//    public override void UpdateEnergyCost()
//    {
//        mEnergyCostTrain = energyCostStrategy.GetSoldierEnergyStrategy(mSoldierType, 1);        
//    }

//    public override void UpgradeCamp()
//    {
//        return;
//    }

//    public override void UpgradeWeapon()
//    {
//        return;
//    }
//}
