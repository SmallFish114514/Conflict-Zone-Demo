using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : IGameSystem
{
    public List<ICharacter> mSoldiers = new List<ICharacter>();
    public List<ICharacter> mEnemies = new List<ICharacter>();
    //private bool isGetTarget = false;
    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }
    public void RemoveSoldiers(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }
    public void AddEnemy(IEnemy enemy)
    {
        mEnemies.Add(enemy);
    }
    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemies.Remove(enemy);
    }
    public override void Update()
    {
        UpdateSoldier();
        UpdateEnemy();
        RemoveIsKilled(mEnemies);
        RemoveIsKilled(mSoldiers);
        UpdateHearts();
    }
    public void UpdateSoldier()
    {
        foreach (ISoldier s in mSoldiers)
        {
            s.Update();
            s.UpdateFsmAI(mEnemies);
        }
    }
    public void UpdateEnemy()
    {
        foreach (IEnemy e in mEnemies)
        {
            e.Update();
            e.UpdateFsmAI(mSoldiers);
        }
    }
    /// <summary>
    /// 移除被消灭的角色
    /// </summary>
    /// <param name="characters"></param>
    public void RemoveIsKilled(List<ICharacter> characters)
    {
        List<ICharacter> canDestroyList = new List<ICharacter>();
        foreach(ICharacter character in characters)
        {
            if (character.CanDestroy)
            {
                canDestroyList.Add(character);
            }
        }
        foreach(ICharacter character in canDestroyList)
        {
            characters.Remove(character);
            character.Release();            
        }
    }
    public void UpdateHearts()
    {
        if (mEnemies.Count == 0)
        {
            return;
        }
        mFacade.Hearts();
    }
    /// <summary>
    /// 运行访问
    /// </summary>
    /// <param name="visitor"></param>
    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach(ICharacter character in mEnemies)
        {
            character.RunVisitor(visitor);
        }
        foreach(ICharacter character in mSoldiers)
        {
            character.RunVisitor(visitor);
        }
    }
}
