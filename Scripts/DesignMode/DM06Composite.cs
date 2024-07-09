using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 组合模式
/// </summary>
public class DM06Composite : MonoBehaviour
{
    private void Start()
    {
        DMComposite Root = new DMComposite("Root");
        DMComposite composite = new DMComposite("GameObject (1)");
        DMLeaf leaf1 = new DMLeaf("GameObject");
        DMLeaf leaf2 = new DMLeaf("GameObject (2)");
        Root.AddChild(leaf1);
        Root.AddChild(composite);
        Root.AddChild(leaf2);        
        DMLeaf child1 = new DMLeaf("GameObject");
        DMLeaf child2 = new DMLeaf("GameObject1");
        composite.AddChild(child1);
        composite.AddChild(child2);

        ReadComponent(Root);
    }
    /// <summary>
    /// 使用深度优先探索以及递归遍历组件
    /// </summary>
    /// <param name="compoent"></param>
    private void ReadComponent(DMCompoent compoent)
    {
        Debug.Log(compoent.Name);
        List<DMCompoent> children = compoent.Children;
        if (children == null || children.Count == 0) return;
        foreach(DMCompoent c in children)
        {
             ReadComponent(c);
        }
    }
}
public abstract class DMCompoent
{
    protected string mName;
    public string Name { get { return mName;} }
    public DMCompoent(string Name)
    {
        mName = Name;
        mChildren = new List<DMCompoent>();
    }
    //集合存储子节点
    protected List<DMCompoent> mChildren;
    public List<DMCompoent> Children { get { return mChildren; } }
    public abstract void AddChild(DMCompoent c);
    public abstract void RemoveChild(DMCompoent c);
    public abstract DMCompoent GetChild(int index);
}
/// <summary>
/// 叶子节点，无子节点
/// </summary>
public class DMLeaf : DMCompoent
{
    public DMLeaf(string Name) : base(Name) { }
    public override void AddChild(DMCompoent c)
    {
        return;
    }

    public override DMCompoent GetChild(int index)
    {
        return null;
    }

    public override void RemoveChild(DMCompoent c)
    {
        return;
    }
}
/// <summary>
/// 枝节点，有子节点
/// </summary>
public class DMComposite : DMCompoent
{
    public DMComposite(string Name) : base(Name) { }
    public override void AddChild(DMCompoent c)
    {
        mChildren.Add(c);
    }

    public override DMCompoent GetChild(int index)
    {
        return mChildren[index];
    }

    public override void RemoveChild(DMCompoent c)
    {
        mChildren.Remove(c);
    }
}
