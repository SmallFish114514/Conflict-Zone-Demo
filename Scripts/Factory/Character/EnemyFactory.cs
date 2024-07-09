using System.Collections;
using UnityEngine;
public class EnemyFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(Vector3 spawnPos, WeaponType weaponType, int Level = 1)where T:ICharacter,new()
    {
        ICharacter character = new T();
        ICharacterBuilder enemyBuilder = new EnemyBuilder(character,typeof(T), weaponType, spawnPos, Level);
        return CharacterBuilderDirectior.Construct(enemyBuilder);
    }
}
