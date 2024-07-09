using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponFactory 
{
    public IWeapon CreatWeapon(WeaponType weaponType);
}
