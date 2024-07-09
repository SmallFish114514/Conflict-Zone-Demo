using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ICamp
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected Vector3 mPos;//集结点
    protected SoldierType mSoldierType;
    protected float mTrainTime;
    protected float mTrainTimer=0;//训练计时器
    protected List<ITrainCommand> mCommands;
    protected IEnergyCostStrategy energyCostStrategy;

    protected int mEnergyCostCampUpgrade;
    protected int mEnergyCostWeaponUpgrade;
    protected int mEnergyCostTrain;
    public ICamp (GameObject gameObject,string name,string IconSprite,Vector3 Pos,SoldierType soldierType,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = IconSprite;
        mPos = Pos;
        mSoldierType = soldierType;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;
        mCommands = new List<ITrainCommand>();        
    }
    public string Name { get { return mName; } }
    public string IconSprite { get { return mIconSprite; } }
    public abstract int level { get; }
    public abstract WeaponType weaponType { get; } 
    public abstract int energyCostWeaponUpgrade{ get; }
    public abstract int energyCostCampUpgrade { get; }
    public abstract int energyCostSoldierUpgrade { get; }
    public virtual void Update()
    {
        UpdateCommand();
    }
    /// <summary>
    /// 更新命令
    /// </summary>
    public void UpdateCommand()
    {
        if (mCommands.Count <= 0) return;
        mTrainTimer -= Time.deltaTime;
        if (mTrainTimer <= 0)
        {
            mCommands[0].Execute();//第一个命令先执行
            mCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;            
        }        
    }
    public abstract void Train();
    public abstract void UpdateEnergyCost();
    public abstract void UpgradeCamp();
    public abstract void UpgradeWeapon();
    public void CancelTrainCommand()
    {
        if (mCommands.Count > 0)
        {
            mCommands.RemoveAt(mCommands.Count - 1);//取消最后一个索引的命令
            if (mCommands.Count == 0)
            {
                mTrainTimer = mTrainTime;
            }
        }            
    }
    public int trainCount { get { return mCommands.Count; } }
    public float trainRemainingTime { get { return mTrainTimer; } }
}