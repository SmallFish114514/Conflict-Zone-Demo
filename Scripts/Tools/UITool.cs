using System.Collections;
using UnityEngine;
public static class UITool
{
    public static GameObject GetCanvas(string name = "Canvas")
    {
        return GameObject.Find(name);
    }
    public static T FindChild<T>(GameObject parent,string childName)
    {
        GameObject uiGo = UnityTool.FindChild(parent, childName);
        //错误提示
        if (uiGo == null) 
        {
            Debug.LogError("在游戏物体下" + parent + "下面查找不到" + childName);
            return default(T);//如果T是引用类型，则返回Null
        }        
        return uiGo.GetComponent<T>();                    
    }
    
}
