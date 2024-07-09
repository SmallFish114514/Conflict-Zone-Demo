using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 工厂模式
/// </summary>
public interface ICharacterFactory
{
    ICharacter CreateCharacter<T>(Vector3 spawnPos, WeaponType weaponType, int Level = 1) where T : ICharacter, new();

}
