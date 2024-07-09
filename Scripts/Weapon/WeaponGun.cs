using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : IWeapon
{
    public WeaponGun(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }
    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.2f;
    }
    protected override void PlayBulletEffect(Vector3 targetPos)
    {
        DoPlayBulletEffect(0.05f, targetPos);
    }

    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }
}
