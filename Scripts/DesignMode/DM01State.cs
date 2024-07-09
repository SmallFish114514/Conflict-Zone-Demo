using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM01State : MonoBehaviour
{
    private void Start()
    {
        Context context = new Context();
        context.SetState(new ConcreteStateA(context));//默认状态
        context.Handle(11);
        context.Handle(4);
        context.Handle(20);
    }
}
public class Context
{
    private IState mState;
    public void SetState(IState state)
    {
        mState = state;
    }
    public void Handle(int arg)
    {
        mState.Handle(arg);
    }
}
public interface IState
{
    void Handle(int arg);
}
public class ConcreteStateA : IState
{
    private Context mContext;
    public ConcreteStateA (Context contexent)
    {
        mContext = contexent;
    }
    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateA.Handle()" + arg);
        if (arg > 10)
        {
            //转换成b状态
            mContext.SetState(new ConcreteStateB(mContext));
        }
    }
}
public class ConcreteStateB : IState
{
    private Context mContext;
    public ConcreteStateB(Context context)
    {
        mContext = context;
    }
    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateB.Handle()" + arg);
        if (arg < 10)
        {
            //转换成a状态
            mContext.SetState(new ConcreteStateA(mContext));
        }
    }
}