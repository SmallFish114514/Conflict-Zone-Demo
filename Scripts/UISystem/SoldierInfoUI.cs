using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoldierInfoUI : IBaseUI
{
    private Image mCampIcon;
    private Text mCampName;
    private Text mHpText;
    private Slider mHpSlider;
    private Text mLevel;
    private Text mAtk;
    private Text mAtkRange;
    private Text mMoveSpeed;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");

        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mHpText = UITool.FindChild<Text>(mRootUI, "HPNumber");
        mHpSlider = UITool.FindChild<Slider>(mRootUI, "HPSlider");
        mLevel = UITool.FindChild<Text>(mRootUI, "LevelNumber");
        mAtk = UITool.FindChild<Text>(mRootUI, "AtkNumber");
        mAtkRange = UITool.FindChild<Text>(mRootUI, "AtkRangeNumber");
        mMoveSpeed = UITool.FindChild<Text>(mRootUI, "MoveSpeedNumber");

        Hide();
    }
}
