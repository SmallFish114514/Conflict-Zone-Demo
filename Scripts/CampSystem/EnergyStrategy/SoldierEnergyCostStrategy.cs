using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierEnergyCostStrategy : IEnergyCostStrategy
{
    /// <summary>
    /// 得到兵营能量消耗策略
    /// </summary>
    /// <param name="soldierType"></param>
    /// <param name="Lv"></param>
    /// <returns></returns>
    public override int GetCampEnergyStrategy(SoldierType soldierType, int Lv)
    {
        int energy = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;            
            default:
                Debug.LogError("无法获取" + soldierType + "这个兵营升级所消耗的能量值");
                break;
        }
        //兵营等级提升  消耗的能量也随之越多        
        energy += (Lv - 1) * 2;
        if (energy > 100)
            energy = 100;
        return energy;
    }

    public override int GetSoldierEnergyStrategy(SoldierType soldierType,int Lv)
    {
        int energy = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            default:
                Debug.LogError("无法获取训练士兵类型为" + soldierType + "所消耗的能量");
                break;
        }
        energy += (Lv - 1) * 2;
        return energy;
    }

    public override int GetWeaponEnergyStrategy(WeaponType weaponType)
    {
        int energy = 0;
        switch (weaponType)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;           
        }
        return energy;
    }
}