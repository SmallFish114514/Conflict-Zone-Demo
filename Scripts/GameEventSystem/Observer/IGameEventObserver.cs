using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameEventObserver
{
    public abstract void Update();
    /// <summary>
    /// 可能会有不同类型的主题
    /// </summary>
    /// <param name="subject"></param>
    public abstract void SetSubject(IGameEventSubject subject);
}
