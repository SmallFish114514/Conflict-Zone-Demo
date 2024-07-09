using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 享元模式 核心 
/// 于工厂模式组合使用
/// 属性工厂 将属性进行统一管理，同一类型角色将共享同一类对象，避免浪费存储空间
/// </summary>
public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> mCharacterBaseAttrDict;
    private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttrDict;
    public AttrFactory()
    {
        InitCharacterBaseAttr();
        InitWeaponBaseAttr();
    }
    /// <summary>
    /// 获取角色基本属性
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public CharacterBaseAttr GetCharacterAttr(Type type)
    {
        if (mCharacterBaseAttrDict.ContainsKey(type) == false)
        {
            Debug.LogError("无法根据类型" + type + "得到角色基础属性(CharacterBaseAttr");
            return null;
        }
        return mCharacterBaseAttrDict[type];
    }
    /// <summary>
    /// 获取武器基本属性
    /// </summary>
    /// <param name="weaponType"></param>
    /// <returns></returns>
    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
    {
        if (mWeaponBaseAttrDict.ContainsKey(weaponType) == false)
        {
            Debug.LogError("无法根据类型" + weaponType + "获取武器角色基础类型");
            return null;
        }
        return mWeaponBaseAttrDict[weaponType];
    }

    private void InitCharacterBaseAttr()
    {
        mCharacterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>();
        mCharacterBaseAttrDict.Add(typeof(SoldierRookie), new CharacterBaseAttr("新手士兵", 80, 2.5f, "RookieIcon", "Soldier2", 0));
        mCharacterBaseAttrDict.Add(typeof(SoldierSergeant), new CharacterBaseAttr("中士士兵", 90, 3, "SergeantIcon", "Soldier3", 0));
        mCharacterBaseAttrDict.Add(typeof(SoldierCaptain), new CharacterBaseAttr("上尉", 100, 3, "CaptainIcon", "Soldier1", 0));

        mCharacterBaseAttrDict.Add(typeof(EnemyTroll), new CharacterBaseAttr("巨魔", 200, 1, "TrollIcon", "Enemy1", 0.4f));
        mCharacterBaseAttrDict.Add(typeof(EnemyOgre), new CharacterBaseAttr("魔物", 120, 4, "OgreIcon", "Enemy2", 0.3f));
        mCharacterBaseAttrDict.Add(typeof(EnemyElf), new CharacterBaseAttr("精灵", 100, 3, "ElfIcon", "Enemy3",0.2f));
    }
    private void InitWeaponBaseAttr()
    {
        mWeaponBaseAttrDict = new Dictionary<WeaponType, WeaponBaseAttr>();
        mWeaponBaseAttrDict.Add(WeaponType.Gun, new WeaponBaseAttr(20, 5, "手枪", "WeaponGun"));
        mWeaponBaseAttrDict.Add(WeaponType.Rifle, new WeaponBaseAttr(30, 6, "步枪", "WeaponRifle"));
        mWeaponBaseAttrDict.Add(WeaponType.Rocket, new WeaponBaseAttr(40, 8, "火箭", "WeaponRocket"));
    }
    
}