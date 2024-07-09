using System.Collections;
using UnityEngine;
public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy,int level,CharacterBaseAttr baseAttr) : base(strategy,level, baseAttr) { }
}