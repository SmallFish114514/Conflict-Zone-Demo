using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 能量消耗策略
/// </summary>
public abstract class IEnergyCostStrategy
{
    public abstract int GetCampEnergyStrategy(SoldierType soldierType, int Lv);
    public abstract int GetWeaponEnergyStrategy(WeaponType weaponType);
    public abstract int GetSoldierEnergyStrategy(SoldierType soldierType,int Lv);
}
