using System.Collections;
using UnityEngine;

public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLv;
    public TrainCaptiveCommand(EnemyType enemyType,WeaponType weaponType,Vector3 position,int Lv=1)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mPosition = position;
        mLv = Lv;
    }
    public override void Execute()
    {
        IEnemy enemy = null;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyElf>(mPosition, mWeaponType) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mPosition, mWeaponType) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mPosition, mWeaponType) as IEnemy;
                break;
            default:
                Debug.LogError("无法根据EnemyType：" + mEnemyType + "创建角色");
                break;
        }
        GameFacade.Instance.RemoveEnemy(enemy);
        //适配器
        SoldierCaptive soldierCaptive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(soldierCaptive);
    }
}