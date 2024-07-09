using System.Collections;
using UnityEngine;
public class TrainSoldierCommand : ITrainCommand
{
    private Vector3 mSpawnPos;
    private WeaponType mWeaponType;
    private int mLevel;
    private SoldierType mSoldierType;
    public TrainSoldierCommand(Vector3 SpawnPos,WeaponType weaponType,int Level,SoldierType soldierType)
    {
        mSpawnPos = SpawnPos;
        mWeaponType = weaponType;
        mLevel = Level;
        mSoldierType = soldierType;
    }
    public override void Execute()
    {
        switch (mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.soldierFactory.CreateCharacter<SoldierRookie>(mSpawnPos, mWeaponType, mLevel);
                break;
            case SoldierType.Sergeant:
                FactoryManager.soldierFactory.CreateCharacter<SoldierSergeant>(mSpawnPos, mWeaponType, mLevel);
                break;
            case SoldierType.Captain:
                FactoryManager.soldierFactory.CreateCharacter<SoldierCaptain>(mSpawnPos, mWeaponType, mLevel);
                break;            
            default:
                Debug.LogError("无法执行命令，无法根据SoldierType:" + mSoldierType + "创建角色");
                break;
        }
        //Debug.Log(mSoldierType+"TrainSoldierCommand");
    }
}