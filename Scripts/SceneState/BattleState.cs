using System.Collections;
using UnityEngine;

    public class BattleState: ISceneState
    {    
    public BattleState(SceneStateController controller) : base("03BattleScene", controller)
    {

    }
    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }
    public override void StateUpdate() 
    {
        if (GameFacade.Instance.IsGameOver)
        {
            //切换到主菜单模式
            mController.SetState(new MainMenuState(mController));
        }
        GameFacade.Instance.Update();
    }
    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }
}