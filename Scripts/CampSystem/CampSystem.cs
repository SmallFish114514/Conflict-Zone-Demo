using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : IGameSystem
{
    public Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    //public Dictionary<EnemyType, CaptiveCamp> mCaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();
    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
        //InitCamp(EnemyType.Elf);
    }

    public void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string IconSprite = null;
        Vector3 Pos = Vector3.zero;
        float trainTime = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新手兵营";
                IconSprite = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                IconSprite = "SergeantCamp";
                trainTime = 4;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                IconSprite = "CaptainCamp";
                trainTime = 5;
                break;                
            default:
                Debug.LogError("无法根据战士类型" + soldierType + "初始化兵营");
                break;
        }
        gameObject = GameObject.Find(gameObjectName);
        Pos= UnityTool.FindChild(gameObject, "TrainPoint").transform.position;//赋值集结点
        SoldierCamp soldierCamp = new SoldierCamp(gameObject, name, IconSprite, Pos, soldierType, trainTime);
        gameObject.AddComponent<CampOnClick>().camp = soldierCamp;//添加点击显示兵营信息脚本
        mSoldierCamps.Add(soldierType, soldierCamp);
    }
    //public void InitCamp(EnemyType enemyType)
    //{
    //    GameObject gameObject = null;
    //    string gameObjectName = null;
    //    string name = null;
    //    string IconSprite = null;
    //    Vector3 Pos = Vector3.zero;
    //    float trainTime = 0;
    //    //switch (enemyType)
    //    //{
    //    //    case EnemyType.Elf:
    //    //        gameObjectName = "CaptiveCamp";
    //    //        name = "浮兵营";
    //    //        IconSprite = "CaptiveCamp";
    //    //        trainTime = 2;
    //    //        break;            
    //    //    default:
    //    //        Debug.LogError("无法根据敌人类型" + enemyType + "初始化兵营");
    //    //        break;
    //    //}
    //    gameObject = GameObject.Find(gameObjectName);
    //    Pos = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;//赋值集结点
    //    CaptiveCamp camp= new CaptiveCamp(gameObject, name, IconSprite, Pos, enemyType, trainTime);
    //    gameObject.AddComponent<CampOnClick>().camp = camp;//添加点击显示兵营信息脚本
    //    //mCaptiveCamps.Add(enemyType,camp);
    //}
    public override void Update()
    {
        base.Update();
        //更新所有兵营系统内部逻辑
        foreach (SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }
        //foreach(CaptiveCamp camp in mCaptiveCamps.Values)
        //{
        //    camp.Update();
        //}
    }
}
