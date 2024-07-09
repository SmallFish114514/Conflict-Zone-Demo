using System.Collections;
using UnityEngine;
public class WeaponRocket : IWeapon
{
    public WeaponRocket(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }
    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.4f;
    }
    protected override void PlayBulletEffect(Vector3 targetPos)
    {
        DoPlayBulletEffect(0.3f, targetPos);
    }

    protected override void PlaySound( )
    {
        DoPlaySound("RocketShot");
    }
}