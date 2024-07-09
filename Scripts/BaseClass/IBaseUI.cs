using System.Collections;
using UnityEngine;

 public abstract class IBaseUI
{    
    public GameObject mRootUI;
    public GameFacade mGameFacade;
    public virtual void Init() {
        mGameFacade = GameFacade.Instance;  
    }
    public virtual void Update() { }
    public virtual void Release() { }
    public void Show()
    {
        mRootUI.SetActive(true);
    }
    public void Hide()
    {
        mRootUI.SetActive(false);
    }
}