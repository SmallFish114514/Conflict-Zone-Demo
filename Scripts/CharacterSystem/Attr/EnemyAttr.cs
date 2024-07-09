using System.Collections;
using UnityEngine;
public class EnemyAttr : ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy,int level,CharacterBaseAttr baseAttr) : base(strategy,level, baseAttr) { }

}