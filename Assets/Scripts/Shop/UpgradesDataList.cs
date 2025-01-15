using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesList", menuName = "Upgrades/List")]
public class UpgradesDataList : ScriptableObject
{
    [SerializeField] private List<UpgradesData> upgradesDatas;

    public List<UpgradesData> UpgradesDatas { get { return upgradesDatas; } }
}
