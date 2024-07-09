using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : IGameSystem
{
    int mLv = 1;
    List<Vector3> mSpawnPosList;
    private IStageHandler mRootHandler;
    private Vector3 mTargetPos;
    int mCountOfEnemyKilled = 0; 
    public override void Update()
    {
        base.Update();
        mRootHandler.Handle(mLv);        
    }
    public override void Init()
    {
        base.Init();
        InitPos();
        InitStageChain();
        //注册观察者
        mFacade.RegisterObserver(SubjectType.EnemyKilled, new EnemyKilledObserverStageSystem(this));
        //mFacade.RegisterObserver(SubjectType.NewStage, new StageObserverStageSystem(this));
    }
    /// <summary>
    /// 关卡责任链
    /// </summary>
    public void InitStageChain()
    {
        int Lv = 1;
        IStageHandler handler1 = new NormalStageHandler(Lv++, 3, this, EnemyType.Elf, WeaponType.Gun, 3,GetRandomPos());
        IStageHandler handler2 = new NormalStageHandler(Lv++, 6, this, EnemyType.Elf, WeaponType.Rifle, 3, GetRandomPos());
        IStageHandler handler3 = new NormalStageHandler(Lv++, 11, this, EnemyType.Elf, WeaponType.Rocket, 5, GetRandomPos());
        IStageHandler handler4 = new NormalStageHandler(Lv++, 16, this, EnemyType.Ogre, WeaponType.Gun, 5, GetRandomPos());
        IStageHandler handler5 = new NormalStageHandler(Lv++, 21, this, EnemyType.Ogre, WeaponType.Rifle, 5, GetRandomPos());
        IStageHandler handler6 = new NormalStageHandler(Lv++, 27, this, EnemyType.Ogre, WeaponType.Rocket, 6, GetRandomPos());
        IStageHandler handler7 = new NormalStageHandler(Lv++, 33, this, EnemyType.Troll, WeaponType.Gun, 6, GetRandomPos());
        IStageHandler handler8 = new NormalStageHandler(Lv++, 39, this, EnemyType.Troll, WeaponType.Rifle, 6, GetRandomPos());
        IStageHandler handler9 = new NormalStageHandler(Lv++, 45, this, EnemyType.Troll, WeaponType.Rocket, 6, GetRandomPos());
        mRootHandler = handler1;
        handler1.SetNextHandler(handler2).SetNextHandler(handler3).SetNextHandler(handler4).SetNextHandler(handler5).SetNextHandler(handler6)
            .SetNextHandler(handler7).SetNextHandler(handler8).SetNextHandler(handler9);
    }
    /// <summary>
    /// 获取生成敌人的位置
    /// </summary>
    private void InitPos()
    {
        mSpawnPosList = new List<Vector3>();
        int i = 1;
        while (true)
        {
            GameObject go = GameObject.Find("Pos" + i);
            if (go != null)
            {
                i++;
                mSpawnPosList.Add(go.transform.position);
                go.SetActive(false);
            }
            else
                break;
        }
        GameObject targetPos = GameObject.Find("TargetPos");
        mTargetPos = targetPos.transform.position;
        //Debug.Log(mTargetPos);
    }
    public Vector3 TargetPos
    {
        get { return mTargetPos; }
    }
    private Vector3 GetRandomPos()
    {
        return mSpawnPosList[UnityEngine.Random.Range(0, mSpawnPosList.Count)];
    }
    public int GetCountOfEnemyKilled()
    {       
        return mCountOfEnemyKilled;
    }    
    public void EnterNextStage()
    {        
        mLv++;
        mFacade.NotifyObserver(SubjectType.NewStage);        
        //Debug.Log("EnterNextStage");
    }   
    public int VisitStageCount()
    {
        return mLv;
    }
    public int EnemyCountOfKilled
    {
        set { mCountOfEnemyKilled = value; }        
    }    
}
