using System.Collections;
using UnityEngine;

public class AchievementSystemMemento
{
    public int EnemyKilledCount { get; set; }
    public int SoldierKilledCount { get; set; }
    public int MaxStageLv { get; set; }

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", EnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", SoldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", MaxStageLv);
    }
    public void LoadData()
    {
        EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        MaxStageLv = PlayerPrefs.GetInt("MaxStageLv");
    }
}
