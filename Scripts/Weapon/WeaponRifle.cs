using System.Collections;
using UnityEngine;
public class WeaponRifle: IWeapon
{
    public WeaponRifle(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }
    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.1f;
    }
    protected override void PlayBulletEffect(Vector3 targetPos)
    {
        DoPlayBulletEffect(0.1f, targetPos);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RilfleShot");
    }
}