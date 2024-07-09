using System.Collections;
using UnityEngine;
public class EnemyAttrStrategy : IAttrStrategy
{
    /// <summary>
    /// 敌人随机数暴击率输入,暴击伤害也是随机返回
    /// </summary>
    /// <param name="critRate"></param>
    /// <returns></returns>
    public int GetCrit(float critRate)
    {
        if (Random.Range(0, 1.0f) > critRate)
        {
            return (int)(10 * Random.Range(0.6f, 1.0f));
        }
        else
            return 0;
    }
    /// <summary>
    /// 敌人无升级
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public int GetDamageDescVal(int level)
    {
        return 0;
    }

    public int GetExtralHPVal(int level)
    {
        return 0;
    }
}