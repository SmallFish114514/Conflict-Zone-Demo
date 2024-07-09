using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 策略模式
/// </summary>
public class DM03Strategy : MonoBehaviour
{
    private void Start()
    {
        StrategyContext context = new StrategyContext();
        //context.strategy = new ConcreteStrategyA();
        context.strategy = new ConcreteStrategyB();
        context.Cal();
    }           
}
public class StrategyContext
{
    public IStrategy strategy;
    public void Cal()
    {
        strategy.Cal();
    }
}
public interface IStrategy
{
    void Cal();
}
public class ConcreteStrategyA : IStrategy
{
    public void Cal()
    {
        Debug.Log("实现A策略");
    }
}
public class ConcreteStrategyB : IStrategy
{
    public void Cal()
    {
        Debug.Log("实现B策略");
    }
}

