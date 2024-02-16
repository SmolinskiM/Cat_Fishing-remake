using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradesSlot : MonoBehaviour
{
    [SerializeField] private UpgradesData upgradesData;
    [SerializeField] private TextMeshProUGUI upgradePriceText;
    [SerializeField] private Image[] levelCout;

    private int upgradeLevel;
    
    public int UpgradeLevel { get { return upgradeLevel; } }

    private void Awake()
    {
        Shop.TryBuyUpgradesEvent += TryBuyUpgrades;
    }

    private void Start()
    {
        upgradePriceText.text = upgradesData.Price.ToString() + "$";
    }

    private bool TryBuyUpgrades(UpgradesData upgradesData)
    {
        if (this.upgradesData != upgradesData)
        {
            return false;
        }

        if (upgradesData is FishingLineLength fishingLineLength)
        {
            FishingRod.Instance.MaxDistance += fishingLineLength.MaxDistance;
        }
        else if (upgradesData is BiggerBait biggerBait)
        {
            FishingRod.Instance.Hook.Bait.BaitSizeStart += biggerBait.BaitSize;

            if(FishingRod.Instance.Hook.Bait.BaitSize < FishingRod.Instance.Hook.Bait.BaitSizeStart)
            {
                FishingRod.Instance.Hook.Bait.ChangeSizeBait(FishingRod.Instance.Hook.Bait.BaitSizeStart);
            }
        }
        upgradeLevel++;

        ShowUpgradeLevel();

        if (upgradeLevel == upgradesData.LevelUpgradeMax)
        {
            Shop.TryBuyUpgradesEvent -= TryBuyUpgrades;
        }

        return true;
    }

    private void ShowUpgradeLevel()
    {
        levelCout[upgradeLevel - 1].color = Color.black;
    }
}
