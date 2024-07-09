using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 访问者
/// </summary>
public class DM11Visitor : MonoBehaviour
{    
    private void Start()
    {
        DMCube cube = new DMCube();
        DMCube cube2 = new DMCube();
        DMSphere sphere = new DMSphere();
        DMCylinder cylinder = new DMCylinder();

        SharpContainer container = new SharpContainer();
        container.AddSharp(cube);
        container.AddSharp(cube2);
        container.AddSharp(sphere);
        container.AddSharp(cylinder);
        //int count = container.GetSharpCount();
        //int cubeCount = container.GetCubeCount();
        //int Volume = container.GetVolume();

        AmountVisitor amountVisitor = new AmountVisitor();
        container.RunVisitor(amountVisitor);
        int Amount=amountVisitor.count;
        Debug.Log("图形总数" + Amount);
        CubeAmountVisitor cubeAmountVisitor = new CubeAmountVisitor();
        container.RunVisitor(cubeAmountVisitor);
        int CubeAmount = cubeAmountVisitor.cubeCount;
        Debug.Log("正方体图形总数" + CubeAmount);
        EdgeAmountVisitor edgeAmountVisitor = new EdgeAmountVisitor();
        container.RunVisitor(edgeAmountVisitor);
        int edgeCount = edgeAmountVisitor.edgeCount;
        Debug.Log("图形总边数" + edgeCount);
    }
}
public abstract class DMISharp
{
    /// <summary>
    /// 获取总面积
    /// </summary>
    /// <returns></returns>
    //public abstract int GetVolume();

    public abstract void  RunVisitor(ISharpVisitor visitor);
}
class SharpContainer
{
    public List<DMISharp> mSharps = new List<DMISharp>();
    public void AddSharp(DMISharp sharp)
    {
        mSharps.Add(sharp);
    }
    public void RunVisitor(ISharpVisitor visitor)
    {
        foreach(DMISharp sharp in mSharps)
        {
            sharp.RunVisitor(visitor);
        }
    }
    /// <summary>
    /// 获取集合中图形数量
    /// </summary>
    /// <returns></returns>
    public int GetSharpCount()
    {
        return mSharps.Count;
    }
    /// <summary>
    /// 获取集合中正方体数量
    /// </summary>
    /// <returns></returns>
    public int GetCubeCount()
    {
        int count = 0;
        foreach(DMISharp sharp in mSharps)
        {
            if (sharp.GetType() == typeof(DMCube))
                count++;
        }
        return count;
    }

    //public int GetVolume()
    //{
    //    int volume = 0;
    //    foreach(DMISharp sharp in mSharps)
    //    {
    //        volume += sharp.GetVolume();
    //    }
    //    return volume;
    //}
}
public class DMCube : DMISharp
{
    //public override int GetVolume()
    //{
    //    return 30;
    //}
    public override void RunVisitor(ISharpVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}
public class DMSphere : DMISharp
{
    //public override int GetVolume()
    //{
    //    return 50;
    //}
    public override void RunVisitor(ISharpVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}
public class DMCylinder : DMISharp
{
    //public override int GetVolume()
    //{
    //    return 60;
    //}
    public override void RunVisitor(ISharpVisitor visitor)
    {
        visitor.VisitCylider(this);
    }
}
public abstract class ISharpVisitor
{
    public abstract void VisitCube(DMCube cube);
    public abstract void VisitSphere(DMSphere sphere);
    public abstract void VisitCylider(DMCylinder cylinder);
}
public class AmountVisitor : ISharpVisitor
{
    public int count=0;
    public override void VisitCube(DMCube cube)
    {
        count++;
    }

    public override void VisitCylider(DMCylinder cylinder)
    {
        count++;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        count++;
    }
}
public class CubeAmountVisitor : ISharpVisitor
{
    public int cubeCount = 0;
    public override void VisitCube(DMCube cube)
    {
        cubeCount++;
    }

    public override void VisitCylider(DMCylinder cylinder)
    {
        return;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        return;
    }
}
public class EdgeAmountVisitor : ISharpVisitor
{
    public int edgeCount = 0;
    public override void VisitCube(DMCube cube)
    {
        edgeCount += 12;
    }

    public override void VisitCylider(DMCylinder cylinder)
    {
        edgeCount += 2;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        edgeCount += 1;
    }
}