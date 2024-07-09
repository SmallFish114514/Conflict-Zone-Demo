using System.Collections;
using UnityEngine;
using UnityEngine.UI;
 public class StartState : ISceneState
{
    private Image Logo;
    private float mSmoothSpeed=1.0f;
    private float mWaiteForTime = 2.0f;
    public StartState(SceneStateController controller) : base("01StartScene", controller)
    {

    }
    public override void StateStart()
    {
        Logo= GameObject.Find("LoGo").GetComponent<Image>();
        Logo.color = Color.black;               
    }
    public override void StateUpdate()
    {
        Logo.color = Color.Lerp(Logo.color, Color.white, mSmoothSpeed * Time.deltaTime);
        mWaiteForTime -= Time.deltaTime;
        if (mWaiteForTime <= 0)
        {
            mController.SetState(new MainMenuState(mController));
        }        
    }
}
