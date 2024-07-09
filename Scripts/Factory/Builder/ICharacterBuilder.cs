using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 建造者模式
/// </summary>
public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;
    protected System.Type mType;
    protected WeaponType mWeaponType;
    protected Vector3 mSpawnPos;
    protected int mLevel;
    protected string mPrefabName="";
    public ICharacterBuilder(ICharacter character, System.Type type,WeaponType weaponType,Vector3 spawnPos,int Level)
    {
        mCharacter = character;
        mType = type;
        mWeaponType = weaponType;
        mSpawnPos = spawnPos;
        mLevel = Level;
    }
    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
    public abstract ICharacter GetResult();

    public abstract void AddInCharacterSystem();
}
