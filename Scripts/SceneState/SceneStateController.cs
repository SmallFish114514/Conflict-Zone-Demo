using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController:MonoBehaviour
{
    private ISceneState mState {
        get;
        set; 
    }
    private AsyncOperation MAo;
    private bool mIsRunStart= false;
    public void SetState(ISceneState state,bool isLoadScene=true)
    {
        if (mState != null)
        {
            mState.StateEnd();//让上一个场景状态做一下清理工作
        }
        mState = state;
        if (isLoadScene)
        {            
            MAo = SceneManager.LoadSceneAsync(mState.SceneName);//异步加载场景            
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();
            mIsRunStart = true;
        }
    }
    public void StateUpdate()
    {
        //Debug.LogError($"current state: {mState}, instance id: {GetInstanceID()}");
        if (MAo != null && MAo.isDone == false) return;//如果场景还没有加载完成就不需要更新 直接返回
        if (mIsRunStart==false&&mState != null && MAo.isDone == true)
        {
            //场景可能没加载完就执行StateStart()方法，所以进行异步场景加载和条件判断
            mState.StateStart();
            mIsRunStart = true;//仅执行一次
        }
        if (mState != null)
        {
            mState.StateUpdate();            
        }
    }

}
