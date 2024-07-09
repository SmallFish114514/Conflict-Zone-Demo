using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器工厂
/// </summary>
public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreatWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        WeaponBaseAttr baseAttr = FactoryManager.attrFactory.GetWeaponBaseAttr(weaponType);
        GameObject weaponGo = FactoryManager.assetFactory.LoadWeapon(baseAttr.AssetName);
        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(baseAttr, weaponGo);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle(baseAttr, weaponGo);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(baseAttr, weaponGo);
                break;
            default:
                break;
        }
        return weapon;
    }
}
