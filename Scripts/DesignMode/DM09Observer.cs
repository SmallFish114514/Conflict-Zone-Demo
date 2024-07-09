using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 观察者模式
/// </summary>
public class DM09Observer : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //WeatherStation ws = new WeatherStation();
        //BillBroadA broadA = new BillBroadA();
        //BillBroadB broadB = new BillBroadB();
        //BillBroadC broadC = new BillBroadC();
        //ws.Update(broadA,broadB,broadC);        

        ConcreteSubject1 subject1 = new ConcreteSubject1();
        ConcreteObserver1 observer1 = new ConcreteObserver1(subject1);
        ConcreteObserver2 observer2 = new ConcreteObserver2(subject1);
        subject1.RegisterObserver(observer1);
        subject1.RegisterObserver(observer2);
        subject1.SubjectState = "气温显示零下90度";
    }    
}
//public class WeatherStation
//{
//    public void Update(BillBroadA A,BillBroadB B,BillBroadC C)
//    {
//        A.Show();
//        B.Show();
//        C.Show();
//    }
//}
//public class BillBroadA
//{
//    public void Show()
//    {
//        Debug.Log("A面板显示天气信息");
//    }
//}
//public class BillBroadB
//{
//    public void Show()
//    {
//        Debug.Log("B面板显示天气信息");
//    }
//}
//public class BillBroadC
//{
//    public void Show()
//    {
//        Debug.Log("C面板显示天气信息");
//    }
//}
public abstract class Subject
{
    //存储自己的观察者
    public List<Observer> mObservers = new List<Observer>();
    public void RegisterObserver(Observer observer)
    {
        mObservers.Add(observer);
    }
    public void RemoveObserver(Observer observer)
    {
        mObservers.Remove(observer);
    }
    /// <summary>
    /// 通知观察者更新
    /// </summary>
    /// <param name="observer"></param>
    public void NotifyObserver()
    {
        foreach(Observer ob in mObservers)
        {
            ob.Update();
        }        
    }
}
/// <summary>
/// 具体实现的主题
/// </summary>
public class ConcreteSubject1 : Subject
{
    private string mSubjectState;
    public string SubjectState
    {
        set { mSubjectState = value;NotifyObserver(); }
        get { return mSubjectState; }
    }
}
public abstract class Observer
{
    public abstract void Update();
}
/// <summary>
/// 具体实现的观察者
/// </summary>
public class ConcreteObserver1 : Observer
{
    public ConcreteSubject1 mConcreteSubject1;
    public ConcreteObserver1(ConcreteSubject1 concreteSubject1)
    {
        mConcreteSubject1 = concreteSubject1;
    }
    public override void Update()
    {
        Debug.Log("Observer1更新显示" + mConcreteSubject1.SubjectState);
    }
}
public class ConcreteObserver2 : Observer
{
    public ConcreteSubject1 mConcreteSubject1;
    public ConcreteObserver2(ConcreteSubject1 concreteSubject1)
    {
        mConcreteSubject1 = concreteSubject1;
    }
    public override void Update()
    {
        Debug.Log("Observer2更新显示" + mConcreteSubject1.SubjectState);
    }
}
