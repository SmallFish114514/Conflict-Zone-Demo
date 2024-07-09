using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnerySystem : IGameSystem
{
    private const int MAX_Energy = 100;
    private float mNowEnergy=MAX_Energy;
    private float RecoverSpeed = 3;//能量恢复速度 每秒恢复3点
    public override void Init()
    {
        base.Init();                
    }
    public override void Update()
    {
        base.Update();
        mFacade.UpdateEnergySlider((int)mNowEnergy, MAX_Energy);
        if (mNowEnergy >= MAX_Energy) return;
        mNowEnergy += RecoverSpeed * Time.deltaTime;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_Energy);        
    }
    public bool TakeEnergy(int Value)
    {
        if (mNowEnergy >= Value)
        {
            mNowEnergy -= Value;
            return true;
        }
        else
            return false;
    }
    /// <summary>
    /// 点击取消训练 回收能量
    /// </summary>
    /// <param name="Value"></param>
    public void CycleEnergy(int Value)
    {
        mNowEnergy = Value;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_Energy);
    }
}
