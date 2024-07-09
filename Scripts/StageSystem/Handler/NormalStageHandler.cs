using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageHandler : IStageHandler
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mCount;//总的敌人数量
    private Vector3 mPos;    
    private int mCountSpawned=0;//已经生成的敌人数量
    private int mSpawnTime = 3;
    private float mSpawnTimer;
    public NormalStageHandler(int Lv,int CountToFinshed,StageSystem stageSystem, EnemyType EnemyType, WeaponType WeaponType, int Count, Vector3 Pos)
        :base(Lv,CountToFinshed,stageSystem)
    {
        mEnemyType = EnemyType;
        mWeaponType = WeaponType;
        mCount = Count;
        mPos = Pos;
        mSpawnTimer = mSpawnTime;
    }
    public override void UpdateStage()
    {
        base.UpdateStage();
        if (mCountSpawned<mCount)
        {
            mSpawnTimer -= Time.deltaTime;
            if (mSpawnTimer<0)
            {
               // Debug.Log(mSpawnTimer);
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
            }
        }
    }
    public void SpawnEnemy()
    {
        mCountSpawned++;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.enemyFactory.CreateCharacter<EnemyElf>(mPos,mWeaponType);
                break;
            case EnemyType.Ogre:
                FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mPos, mWeaponType);
                break;
            case EnemyType.Troll:
                FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mPos, mWeaponType);
                break;
            default:
                Debug.LogError("无法生成敌人类型：" + mEnemyType);
                break;
        }
    }
}
