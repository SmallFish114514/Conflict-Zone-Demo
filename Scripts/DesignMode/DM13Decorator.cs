using System.Collections;
using UnityEngine;

/// <summary>
/// 装饰模式
/// </summary>
public class DM13Decorator : MonoBehaviour
{
    private void Start()
    {
        Cofee cofee = new Decaf();
        cofee= cofee.AddDressing(new Mocha());
        cofee= cofee.AddDressing(new Whip());
        cofee = cofee.AddDressing(new Mocha());
        Debug.Log(cofee.Cost());
        Debug.Log(cofee.Capacity());
    }
}
public abstract class Cofee
{
    /// <summary>
    /// 需要装饰的属性
    /// </summary>
    /// <returns></returns>
    public abstract double Cost();
    public abstract int Capacity();
    public Cofee AddDressing(Dressing dressing)
    {
        dressing.cofee = this;
        return dressing;
    }
}
/// <summary>
/// 咖啡
/// </summary>
public class Decaf : Cofee
{
    public override int Capacity()
    {
        return 10;
    }

    public override double Cost()
    {
        return 2;
    }
}
/// <summary>
/// 咖啡
/// </summary>
public class Espresso : Cofee
{
    public override int Capacity()
    {
        return 5;
    }

    public override double Cost()
    {
        return 2.5;
    }
}
/// <summary>
/// 装饰者
/// </summary>
public class Dressing : Cofee
{
    protected Cofee mCofee;
    //public Dressing(Cofee cofee)
    //{
    //    mCofee = cofee;
    //}
    public Cofee cofee
    {
        set { mCofee = value; }
    }

    public override int Capacity()
    {
        return mCofee.Capacity();
    }

    public override double Cost()
    {
        return mCofee.Cost();
    }
}
/// <summary>
/// 调味品
/// </summary>
public class Mocha : Dressing
{
    //public Mocha(Cofee cofee) : base(cofee)
    //{
    //}
    public override double Cost()
    {
        return mCofee.Cost()+0.1;
    }
    public override int Capacity()
    {
        return mCofee.Capacity() + 1;
    }
}
/// <summary>
/// 调味品
/// </summary>
public class Whip : Dressing
{
    //public Whip(Cofee cofee) : base(cofee)
    //{
    //}
    public override double Cost()
    {
        return mCofee.Cost() + 0.5;
    }
    public override int Capacity()
    {
        return mCofee.Capacity() + 2;
    }
}
