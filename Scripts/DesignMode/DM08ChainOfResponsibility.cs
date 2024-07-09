using System.Collections;
using UnityEngine;
/// <summary>
/// 责任链模式
/// </summary>
public class DM08ChainOfResponsibility : MonoBehaviour
{
    private void Start()
    {
        char problem = 'b';
        //switch (problem)
        //{
        //    case ('a'):
        //        new DMHandlerA().Handle();
        //        break;
        //    case ('b'):
        //        new DMHandlerB().Handle();
        //        break;
        //}
        DMHandlerA handlerA = new DMHandlerA();
        DMHandlerB handlerB = new DMHandlerB();
        DMHandlerC handlerC = new DMHandlerC();
        //handlerA.NextHandler = handlerB;
        //handlerB.NextHandler = handlerC;
        handlerA.SetNextHandler(handlerB).SetNextHandler(handlerC);
        handlerA.Handle(problem);
    }
}
public abstract class IDMHandler
{
    protected IDMHandler mNextHandler;
    public IDMHandler NextHandler
    {
        set { mNextHandler = value; }
    }
    /// <summary>
    /// 设置下一个处理者
    /// </summary>
    /// <param name="handler"></param>
    /// <returns></returns>
    public IDMHandler SetNextHandler(IDMHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }
    public abstract void Handle(char problem);
}
public class DMHandlerA:IDMHandler
{    
    public override void Handle(char problem)
    {
        if(problem=='a')
        Debug.Log("处理了A问题");
        else
        {
            if (mNextHandler != null)
                mNextHandler.Handle(problem);
        }
        
    }
}
public class DMHandlerB:IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'b')
            Debug.Log("处理了B问题");
        else
        {
            if (mNextHandler != null)
                mNextHandler.Handle(problem);
        }

    }
}
public class DMHandlerC : IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'c')
            Debug.Log("处理了C问题");
        else
        {
            if (mNextHandler != null)
                mNextHandler.Handle(problem);
        }

    }
}
