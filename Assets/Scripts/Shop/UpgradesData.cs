using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesData : ScriptableObject
{
    [SerializeField] private string description;

    [SerializeField] private int price;
    [SerializeField] private int levelUpgradeMax;

    public string Description { get { return description; } }

    public int Price { get { return price; } }
    public int LevelUpgradeMax { get { return levelUpgradeMax; } }
}

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades/FishingLineLength")]
public class FishingLineLength : UpgradesData
{
    [SerializeField] private int maxDistance;

    public int MaxDistance { get { return maxDistance; } }
}

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades/BiggerBait")]
public class BiggerBait : UpgradesData
{
    [SerializeField] private int baitSize;

    public int BaitSize { get { return baitSize; } }
}
