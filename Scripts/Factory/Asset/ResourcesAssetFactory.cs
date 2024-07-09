using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAssetFactory : IAssetFactory
{
    /// <summary>
    /// 加载资源路径
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string AudioPath = "Audios/";
    public const string EffectPath = "Effects/";
    public const string SpritePath = "Sprites/";
    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(AudioPath + name, typeof(AudioClip)) as AudioClip;
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath + name);
    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }
    /// <summary>
    /// 实例化路径下的游戏物体
    /// </summary>
    /// <param name="Path"></param>
    /// <returns></returns>
    private GameObject InstantiateGameObject(string Path)
    {
        UnityEngine.Object O = Resources.Load(Path);
        if (O == null)
        {
            Debug.LogError("无法加载资源，路径：" + Path); return null;
        }
        return UnityEngine.GameObject.Instantiate(O) as GameObject;
    }
    /// <summary>
    /// 不需要实例化路径下物体
    /// </summary>
    /// <param name="Path"></param>
    /// <returns></returns>
    public Object LoadAsset(string Path)
    {
        //Debug.Log(Path);
        Object O = Resources.Load(Path);
        if (O == null)
        {
            Debug.LogError("无法加载资源，路径：" + Path); return null;
        }
        return O;
    }
}
