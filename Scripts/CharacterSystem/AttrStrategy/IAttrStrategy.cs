using System.Collections;
using UnityEngine;
public interface IAttrStrategy
{
     int GetExtralHPVal(int level);
     int GetDamageDescVal(int level);
     int GetCrit(float critRate);
}