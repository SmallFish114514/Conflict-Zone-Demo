using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, System.Type type, WeaponType weaponType, Vector3 spawnPos, int Level) : base(character,type, weaponType, spawnPos, Level) 
    { 
    }
    public override void AddCharacterAttr()
    {
        //设置属性
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterAttr(mType);
        mPrefabName = baseAttr.PrefabName;
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), mLevel,baseAttr);
        mCharacter.Attr = attr;
    }
    public override void AddGameObject()
    {
        GameObject characterGo = FactoryManager.assetFactory.LoadEnemy(mPrefabName);
        characterGo.transform.position = mSpawnPos;
        mCharacter.gameObject = characterGo;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddEnemy(mCharacter as IEnemy);
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
