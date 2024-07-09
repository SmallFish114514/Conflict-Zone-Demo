using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IAttrFactory
{
    CharacterBaseAttr GetCharacterAttr(System.Type type);
    WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType);
}
