using System.Collections;
using UnityEngine;

/// <summary>
/// 外观模式 ，中介者
/// </summary>
 public class GameFacade
{
    private static GameFacade _Instance = new GameFacade();
    private bool mIsGameOver = false;
    public bool IsGameOver { get { return mIsGameOver; } set { mIsGameOver = value; } }     
    //定义内部进行实例化
    public static GameFacade Instance { get { return _Instance; } }//外部通过构造函数进行访问
    private GameFacade() { }//私有化，不让外部调用构造方法实例化
    /// <summary>
    /// 充当中介者
    /// </summary>
    private ArchievementSystem mArchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnerySystem mEnerySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;    

    public void Init()
    {
        mGameEventSystem = new GameEventSystem();
        mArchievementSystem = new ArchievementSystem();
        //mArchievementSystem =  new GameObject("ArchievementSystem").AddComponent<ArchievementSystem>();
        mArchievementSystem.Init();
        mCampSystem = new CampSystem();
        //mCampSystem = gameObject.AddComponent<CampSystem>();
        mCampSystem.Init();
        mCharacterSystem = new CharacterSystem();
        mCharacterSystem.Init();
        mEnerySystem = new EnerySystem();
        mEnerySystem.Init();        
        mGameEventSystem.Init();
        mStageSystem = new StageSystem();
        mStageSystem.Init();

        mCampInfoUI = new CampInfoUI();
        //mCampInfoUI = gameObject.AddComponent<CampInfoUI>();
        mCampInfoUI.Init();
        mGamePauseUI = new GamePauseUI();
        //mGamePauseUI = gameObject.AddComponent<GamePauseUI>();
        mGamePauseUI.Init();
        mGameStateInfoUI = new GameStateInfoUI();
        //mGameStateInfoUI = gameObject.AddComponent<GameStateInfoUI>();
        mGameStateInfoUI.Init();
        mSoldierInfoUI = new SoldierInfoUI();
        //mSoldierInfoUI = gameObject.AddComponent<SoldierInfoUI>();
        mSoldierInfoUI.Init();
        
        LoadMemento();
    }
    // Update is called once per frame
    public void Update()
    {
        mArchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnerySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }
    public void Release()
    {
        mArchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnerySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();

        CreateMemento();
    }
    public Vector3 GetEnemyTargetPos()
    {
        return mStageSystem.TargetPos;
    }
    public void ShowCampInfo(ICamp camp)
    {
        mCampInfoUI.ShowCampInfo(camp);
    }
    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSoldier(soldier);
    }
    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }
    public void RemoveEnemy(IEnemy enemy)
    {
        mCharacterSystem.RemoveEnemy(enemy);
    }
    public bool TakeEnergy(int Value)
    {
        return mEnerySystem.TakeEnergy(Value);
    }
    /// <summary>
    /// 显示能量不足信息
    /// </summary>
    /// <param name="Msg"></param>
    public void ShowMsg(string Msg)
    {
         mGameStateInfoUI.ShowMsg(Msg);
    }    
    public void CycleEnergy(int Value)
    {
        mEnerySystem.CycleEnergy(Value);
    }
    public void UpdateEnergySlider(int nowEnergy,int maxEnergy)
    {
        mGameStateInfoUI.UpdateEnergySlider(nowEnergy, maxEnergy);
    }
    public void RegisterObserver(SubjectType subjectType, IGameEventObserver observer)
    {
        mGameEventSystem.RegisterObserver(subjectType, observer);
    }
    public void RemoveObserver(SubjectType subjectType, IGameEventObserver observer)
    {
        mGameEventSystem.RemoveObserver(subjectType, observer);
    }
    public void NotifyObserver(SubjectType subjectType)
    {
        mGameEventSystem.NotifyObserver(subjectType);
    }
    public void CreateMemento()
    {
        AchievementSystemMemento memento = new AchievementSystemMemento();
        memento.SaveData();
    }
    public void LoadMemento()
    {
        AchievementSystemMemento memento = new AchievementSystemMemento();
        memento.LoadData();
        mArchievementSystem.SetMemento(memento);
    }
    public void RunVisitor(ICharacterVisitor visitor)
    {
        mCharacterSystem.RunVisitor(visitor);
    }
    public int VisitStage()
    {
        return mStageSystem.VisitStageCount();
    }
    public void ShowPauseUi()
    {
        mGamePauseUI.Show();
    }
    /// <summary>
    /// 返回目标点位置
    /// </summary>
    /// <returns></returns>
    public Vector3 TargetPos()
    {
        return mStageSystem.TargetPos;
    }
    int i = 0;
    public void Hearts()
    {        
        float TargetDis = Vector3.Distance(mCharacterSystem.mEnemies[0].Position,TargetPos());        
        if (TargetDis< 1.5f)
        {
            mGameStateInfoUI.mHearts[i].SetActive(false);
            mCharacterSystem.mEnemies[0].CanDestroy = true;
            mCharacterSystem.mEnemies[0].Killed();
            mCharacterSystem.mEnemies[0].gameObject.AddComponent<DestroyForTime>();
            i++;
        }
        if (mGameStateInfoUI.mHearts[2].activeSelf == false)
        {
            IsGameOver = true;
        }
    }
}
