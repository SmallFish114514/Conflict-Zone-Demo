using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTool
{
    /// <summary>
    /// 查找含有多个子物体的父物体下的指定子物体
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="childName"></param>
    /// <returns></returns>
    public static GameObject FindChild(GameObject parent,string childName)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Transform child = null;
        bool isFound = false;
        foreach(Transform c in children)
        {
            if (c.name == childName)
            {
                if (isFound)
                {
                    //可能存在多个名字相同的子物体，发现警告
                    Debug.LogWarning("在游戏物体" + parent + "下存在不止一个子物体" + childName);
                }
                isFound = true;
                child = c;
            }

        }
        if (isFound==true)
            return child.gameObject;
        else
            return null;
    }
    /// <summary>
    /// 连接武器和武器握持点
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="child"></param>
    public static void Attach(GameObject parent,GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = new Vector3(-0.1f, -0.23f, 0.31f);
        child.transform.localScale = new Vector3(1.8f, 0.8f, 1.8f);
        child.transform.localEulerAngles = new Vector3(53.8f, 0, 50.49f);
        parent.transform.localScale = Vector3.one;
    }
}
