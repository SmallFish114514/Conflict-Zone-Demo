using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBuilder: ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, System.Type type, WeaponType weaponType, Vector3 spawnPos, int Level) : base(character, type, weaponType, spawnPos, Level)
    {
    }
    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterAttr(mType);
        mPrefabName = baseAttr.PrefabName;
        //根据创建的不同角色类型，初始化属性
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), mLevel,baseAttr);
        //根据character中的AttrSet方法对角色进行赋值
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        GameObject characterGo = FactoryManager.assetFactory.LoadSoldier(mPrefabName);
        characterGo.transform.position = mSpawnPos;
        mCharacter.gameObject = characterGo;
    }
    /// <summary>
    /// 添加战士
    /// </summary>
    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddSoldier(mCharacter as ISoldier);
    }

    public override void AddWeapon()
    {
        IWeapon weapon = FactoryManager.weaponFactory.CreatWeapon(mWeaponType);
        mCharacter.Weapon = weapon;        
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}
