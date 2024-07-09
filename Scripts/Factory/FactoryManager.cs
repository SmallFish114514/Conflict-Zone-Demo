using System.Collections;
using UnityEngine;
public static class FactoryManager
{
    public static IAssetFactory mAssetFactory = null;
    public static ICharacterFactory mSoldierFactory = null;
    public static ICharacterFactory mEnemyFactory = null;
    public static IWeaponFactory mWeaponFactory = null;
    public static IAttrFactory mAttrFactory = null;

    public static IAssetFactory assetFactory
    {
        get
        {
            if (mAssetFactory == null)
            {
                //mAssetFactory = new ResourcesAssetFactory();
                mAssetFactory = new ResourcesAssetProxyFactory();
            }
            return mAssetFactory;
        }        
    }
    public static ICharacterFactory soldierFactory
    {
        get
        {
            if (mSoldierFactory == null)
            {
                mSoldierFactory = new SoldierFactory();
            }
            return mSoldierFactory;
        }
    }
    public static ICharacterFactory enemyFactory
    {
        get
        {
            if (mEnemyFactory == null)
            {
                mEnemyFactory = new EnemyFactory();
            }
            return mEnemyFactory;
        }
    }
    public static IWeaponFactory weaponFactory
    {
        get
        {
            if (mWeaponFactory == null)
            {
                mWeaponFactory = new WeaponFactory();
            }
            return mWeaponFactory;
        }
    }
    public static IAttrFactory attrFactory
    {
        get
        {
            if (mAttrFactory == null)
            {
                mAttrFactory = new AttrFactory();
            }
            return mAttrFactory;
        }
    }

}