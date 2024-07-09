using System.Collections;
using UnityEngine;
public class DM04TempleMythod : MonoBehaviour
{
    /// <summary>
    /// 模板方法模式
    /// </summary>
    private void Start()
    {
        //Ipepole pepole = new NorthPepole();
        //Ipepole pepole = new SouthPepole();
        Ipepole pepole = new AmericaPepole();
        pepole.Eat();
    }
}
public abstract class Ipepole
{
    public void Eat()
    {
        Ordering();
        EatingSomting();
        PayBill();
    }
    private void Ordering()
    {
        Debug.Log("点单");
    }
    protected virtual void EatingSomting()
    {

    }
    private void PayBill()
    {
        Debug.Log("买单");
    }
}
public class NorthPepole : Ipepole
{
    protected override void EatingSomting()
    {
        Debug.Log("北方人吃面条");
    }
}
public class SouthPepole : Ipepole
{
    protected override void EatingSomting()
    {
        Debug.Log("南方人吃米饭");
    }
}
public  class AmericaPepole : Ipepole
{
    protected override void EatingSomting()
    {
        Debug.Log("美国人吃麦当劳");
    }
}