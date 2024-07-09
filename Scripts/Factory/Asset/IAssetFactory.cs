using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽象工厂模式
/// </summary>
public interface IAssetFactory
{
     GameObject LoadSoldier(string name);
     GameObject LoadEnemy(string name);
     GameObject LoadWeapon(string name);
     GameObject LoadEffect(string name);
     Sprite LoadSprite(string name);
     AudioClip LoadAudioClip(string name);
}
