using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DM10Memento : MonoBehaviour
{
    private void Start()
    {
        //Originator originator = new Originator();
        //originator.SetState("State1");
        //originator.ShowState();
        //Memento memento = originator.CreateMemento();//创建快照,存储备忘录
        //originator.SetState("State2");
        //originator.ShowState();
        //originator.SetMemento(memento);
        //originator.ShowState();

        //使用CareTaker
        Originator originator = new Originator();
        CareTaker careTaker = new CareTaker();
        originator.SetState("State1");
        originator.ShowState();
        careTaker.AddMemento("V1.0", originator.CreateMemento());

        originator.SetState("State2");
        originator.ShowState();
        careTaker.AddMemento("V2.0", originator.CreateMemento());
        originator.SetState("State3");
        originator.ShowState();
        careTaker.AddMemento("V3.0", originator.CreateMemento());

        originator.SetMemento(careTaker.GetMemento("V2.0"));
        originator.ShowState();
        originator.SetMemento(careTaker.GetMemento("V1.0"));
        originator.ShowState();
    }
}
public class Originator
{
    private string mState;
    public void SetState(string State)
    {
        mState = State;
    }    
    public void ShowState()
    {
        Debug.Log("Originator State:" + mState);
    }
    /// <summary>
    /// 创建快照  存储备忘录
    /// </summary>
    /// <returns></returns>
    public Memento CreateMemento()
    {
        Memento memento = new Memento();
        memento.SetState(mState);
        return memento;
    }
    /// <summary>
    /// 从备忘录中取出数据
    /// </summary>
    /// <param name="memento"></param>
    public void SetMemento(Memento memento)
    {
        SetState(memento.GetState());
    }
}
/// <summary>
/// 备忘录
/// </summary>
public class Memento
{
    public string mState;
    public void SetState(string State)
    {
        mState = State;
    }
   public string GetState()
   {
        return mState;
   }
}
/// <summary>
/// 存储多个版本的备忘录
/// </summary>
public class CareTaker
{
    private Dictionary<string, Memento> mementoDic = new Dictionary<string, Memento>();
    public void AddMemento(string version,Memento memento)
    {
        mementoDic.Add(version, memento);
    }
    public Memento GetMemento(string version)
    {
        if (mementoDic.ContainsKey(version)==false)
        {
            Debug.LogError("备忘录字典中不包含" + version);
            return null;
        }
        return mementoDic[version];
    }
}