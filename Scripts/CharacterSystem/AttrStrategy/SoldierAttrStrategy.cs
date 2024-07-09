using System.Collections;
using UnityEngine;
public class SoldierAttrStrategy : IAttrStrategy
{
    /// <summary>
    /// 战士没有暴击率
    /// </summary>
    /// <param name="critRate"></param>
    /// <returns></returns>
    public int GetCrit(float critRate)
    {
        return 0;
    }
    /// <summary>
    /// 每升一级抵御5点伤害
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public int GetDamageDescVal(int level)
    {
        return (level - 1) * 5;
    }
    /// <summary>
    /// 每升一级额外增加10点血量
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public int GetExtralHPVal(int level)
    {
        return (level - 1) * 10;
    }
}