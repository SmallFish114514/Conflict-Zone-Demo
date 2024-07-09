using System.Collections;
using UnityEngine;
public class SoldierCaptive : ISoldier
{
    /// <summary>
    /// 适配器 将敌人转换成战士
    /// </summary>
    private IEnemy mEnemy;
    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;
        ICharacterAttr attr = new EnemyAttr(enemy.Attr.AttrStrategy, 1, enemy.Attr.BaseAttr);
        this.Attr = attr;
        this.gameObject = mEnemy.gameObject;
        this.Weapon = mEnemy.Weapon;
    }
    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }
    protected override void PlaySound()
    {
        //Do Nothing
    }
}
