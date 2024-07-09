using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameEventSubject
{
    private List<IGameEventObserver> observers = new List<IGameEventObserver>();
    public void RegisterObserver(IGameEventObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IGameEventObserver observer)
    {
        observers.Remove(observer);
    }
    public virtual void NotifyObserver()
    {
        foreach(IGameEventObserver observer in observers)
        {
            observer.Update();
        }
    }
}
