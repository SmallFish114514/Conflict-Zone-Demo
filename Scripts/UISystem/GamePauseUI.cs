using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : IBaseUI
{
    private Text mCurrentStage;
    private Button mContinueBtn;
    //protected SceneStateController mController = new SceneStateController();  
    private Button mBackMenuBtn;
    public override void Init()
    {
        base.Init();        
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");
        mCurrentStage = UITool.FindChild<Text>(mRootUI, "CurrentStage");
        mContinueBtn = UITool.FindChild<Button>(mRootUI, "ContinueBtn");
        mBackMenuBtn = UITool.FindChild<Button>(mRootUI, "BackMenuBtn");
        mContinueBtn.onClick.AddListener(OnContinueBtnClick);
        mBackMenuBtn.onClick.AddListener(OnBackBtnClick);
        //mBackMenuBtn.onClick.AddListener(() =>SceneManager.LoadScene("02MainMenu"));
        Hide();
    }
    public override void Update()
    {
        base.Update();
        UpdateStageCount();        
    }
    public void UpdateStageCount()
    {
        mCurrentStage.text = mGameFacade.VisitStage().ToString();
    }    
    void OnContinueBtnClick()
    {
        Time.timeScale = 1f;
        Hide();
    }  

    void OnBackBtnClick()
    {
        var controller = Object.FindObjectOfType<SceneStateController>();
        controller.SetState(new MainMenuState(controller));
    }
}
