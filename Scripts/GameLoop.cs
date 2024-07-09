using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    /// <summary>
    /// GameLoop->SceneStateController（设置默认状态和切换状态的方法）-> 三种状态通过ISceneState实现
    /// </summary>
    private SceneStateController mController;
     void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        mController = gameObject.AddComponent<SceneStateController>();
        mController.SetState(new StartState(mController),false);//默认场景为开始场景，不需要加载，所以设置bool变量进行控制
    }

    // Update is called once per frame
    void Update()
    {
        if(mController!=null)
        mController.StateUpdate();
    }
}
