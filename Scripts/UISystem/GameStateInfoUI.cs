using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInfoUI : IBaseUI
{
    public List<GameObject> mHearts;
    private Text mSoliderCount;
    private Text mEnemyCount;
    private Text mCurrentStage;
    private Button mGamePauseBtn;
    private GameObject mGameOverUI;
    private Text mMessage;
    private Slider mEnergySlider;
    private Text mEnergyText;
    private AliveCountVisitor mAliveCountVisitor = new AliveCountVisitor();

    private float mMsgTimer = 0;
    private float mMsgTime = 2;
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GameStateUI");
        mHearts = new List<GameObject>();

        GameObject heart1 = UnityTool.FindChild(mRootUI, "Heart");
        GameObject heart2 = UnityTool.FindChild(mRootUI, "Heart2");
        GameObject heart3 = UnityTool.FindChild(mRootUI, "Heart3");
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);
        //mHearts[2].gameObject.SetActive(false);
        mSoliderCount = UITool.FindChild<Text>(mRootUI, "SoldierCount");
        mEnemyCount = UITool.FindChild<Text>(mRootUI, "EnemyCount");
        mCurrentStage = UITool.FindChild<Text>(mRootUI, "StageCounter");
        mGamePauseBtn = UITool.FindChild<Button>(mRootUI, "PauseBtn");
        mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
        mEnergyText = UITool.FindChild<Text>(mRootUI, "EnergyText");
        mMessage = UITool.FindChild<Text>(mRootUI, "Message");
        mGameOverUI = UnityTool.FindChild(mRootUI, "GameOverUI");
        mMessage.text = "";
        mGameOverUI.SetActive(false);
        mGamePauseBtn.onClick.AddListener(OnPauseBtnClick);
    }
    public override void Update()
    {
        base.Update();
        UpdateAliveCount();
        UpdateStageCount();
        if (mMsgTimer > 0)
        {
            mMsgTimer -= Time.deltaTime;
            if (mMsgTimer <= 0)
                mMessage.text = "";
        }                                
    }
    public void ShowMsg(string Msg)
    {
        mMessage.text = Msg;
        mMsgTimer = mMsgTime;
    }
    public void UpdateEnergySlider(int nowEnergy, int maxEnergy)
    {
        mEnergySlider.value = (float)nowEnergy / maxEnergy;
        mEnergyText.text = "(" + nowEnergy + "/" + maxEnergy + ")";
    }
    public void UpdateAliveCount()
    {
        mAliveCountVisitor.Reset();
        mGameFacade.RunVisitor(mAliveCountVisitor);
        mEnemyCount.text = mAliveCountVisitor.enemyAliveCount.ToString();
        mSoliderCount.text = mAliveCountVisitor.soldierAliveCount.ToString();
    }
    public void UpdateStageCount()
    {
        mCurrentStage.text = mGameFacade.VisitStage().ToString();
    }
    void OnPauseBtnClick()
    {
        mGameFacade.ShowPauseUi();
        Time.timeScale = 0;
    }    
}

