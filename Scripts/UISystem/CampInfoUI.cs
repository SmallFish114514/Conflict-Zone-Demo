using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI : IBaseUI
{
    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;
    private Button mCampLevelUpBtn;
    private Button mWeaponLevelUpBtn;
    private Button mTrainBtn;
    private Button mCancelTrainBtn;
    private Text mAliveCount;
    private Text mTrainingCount;
    private Text mTrainTime;
    private Text mTrainBtnText;
    private ICamp mCamp;
    private AliveCountVisitor mAliveCountVisitor = new AliveCountVisitor();
    public override void Init()
    {
        base.Init();
         GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");
        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITool.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLevel = UITool.FindChild<Text>(mRootUI, "WeaponLv");
        mWeaponLevelUpBtn = UITool.FindChild<Button>(mRootUI, "WeaponLevelUpBtn");
        mCampLevelUpBtn = UITool.FindChild<Button>(mRootUI, "CampLevelUpBtn");
        mTrainBtn = UITool.FindChild<Button>(mRootUI, "TrainBtn");
        mCancelTrainBtn = UITool.FindChild<Button>(mRootUI, "ConcelTrainBtn");
        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainingCount = UITool.FindChild<Text>(mRootUI, "TrainingCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");
        mTrainBtnText = UITool.FindChild<Text>(mRootUI, "TrainBtnText");
        
        mTrainBtn.onClick.AddListener(OnTrainBtnClick);        
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainBtnClick);
        mWeaponLevelUpBtn.onClick.AddListener(OnWeaponUpgradeClick);
        mCampLevelUpBtn.onClick.AddListener(OnCampUpgradeClick);
        
        //Debug.Log(mTrainBtn.onClick);
        Hide();

    }
    public override void Update()
    {
        base.Update();
        if(mCamp!=null)
        ShowTrainingInfo();
        UpdateSoldierAliveCount();
    }
    /// <summary>
    /// 点击鼠标显示兵营信息
    /// </summary>
    /// <param name="camp"></param>
    public void ShowCampInfo(ICamp camp)
    {
        Show();
        mCamp = camp;
        //Debug.Log(camp.IconSprite);
        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.IconSprite);
        mCampName.text = camp.Name;
        mCampLevel.text = camp.level.ToString();
        ShowWeaponType(camp.weaponType);
        //显示鼠标点击训练所需的能量
        mTrainBtnText.text = "Train\n" + mCamp.energyCostSoldierUpgrade + "Enery";
        ShowTrainingInfo();
    }
    private void UpdateSoldierAliveCount()
    {
        mAliveCountVisitor.Reset();
        mGameFacade.RunVisitor(mAliveCountVisitor);
        mAliveCount.text = mAliveCountVisitor.soldierAliveCount.ToString();
    }
    public void ShowTrainingInfo()
    {
        mTrainingCount.text = mCamp.trainCount.ToString();
        mTrainTime.text = mCamp.trainRemainingTime.ToString("0.00");
        if (mCamp.trainCount == 0)
            mCancelTrainBtn.interactable = false;
        else
            mCancelTrainBtn.interactable = true;
    }
    void ShowWeaponType(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "Rifle";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "Gun";
                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "Rocket";
                break;
            case WeaponType.Max:
                break;
            default:
                break;
        }
    }
    void OnTrainBtnClick()
    {
        int energy = mCamp.energyCostSoldierUpgrade;
        if (mGameFacade.TakeEnergy(energy))
        {
            mCamp.Train();
        }
        else
            mGameFacade.ShowMsg("训练士兵需要能量:" + energy + " 能量不足，无法训练新的士兵");
    }
    void OnCancelTrainBtnClick()
    {
        mGameFacade.CycleEnergy(mCamp.energyCostSoldierUpgrade);
        mCamp.CancelTrainCommand();
    }
    void OnCampUpgradeClick()
    {
        int energy = mCamp.energyCostCampUpgrade;        
        if (energy < 0)
        {
            mGameFacade.ShowMsg("兵营已到最大等级，无法在进行升级");
            return;
        }
        if (mGameFacade.TakeEnergy(energy))
        {
            mCamp.UpgradeCamp();
            ShowCampInfo(mCamp);
        }
        else
            mGameFacade.ShowMsg("训练兵营需要能量: " + energy + "能量不足，请稍后进行升级");
    }
    void OnWeaponUpgradeClick()
    {
        int energy = mCamp.energyCostWeaponUpgrade;        
        if (energy < 0)
        {
            mGameFacade.ShowMsg("武器已到最大等级，无法在进行升级");
            return;
        }
        if (mGameFacade.TakeEnergy(energy))
        {
            mCamp.UpgradeWeapon();
            ShowCampInfo(mCamp);
        }
        else
            mGameFacade.ShowMsg("训练武器需要能量"+energy+"能量不足，请稍后进行升级");
    }
}
