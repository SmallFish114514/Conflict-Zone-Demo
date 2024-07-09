using System.Collections;
using UnityEngine;
/// <summary>
/// 创建角色
/// </summary>
public class SoldierFactory: ICharacterFactory
{
    public ICharacter CreateCharacter<T>(Vector3 spawnPos, WeaponType weaponType, int Level = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
        ICharacterBuilder soldierBuilder = new SoldierBuilder(character, typeof(T), weaponType, spawnPos, Level);
        return CharacterBuilderDirectior.Construct(soldierBuilder);
    }
}