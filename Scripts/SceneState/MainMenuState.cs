using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuState : ISceneState
{
    public MainMenuState (SceneStateController controller) : base("02MainMenu", controller)
    {

    }
    public override void StateStart()
    {
        GameObject.Find("StartGame").GetComponent<Button>().onClick.AddListener(OnButtonClickDown);
    }
    public void OnButtonClickDown()
    {
        Time.timeScale = 1;
        GameFacade.Instance.IsGameOver = false;
        mController.SetState(new BattleState(mController));
    }
}
