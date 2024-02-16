using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public delegate bool TryBuyUpgrades(UpgradesData upgradesData);

    public static event TryBuyUpgrades TryBuyUpgradesEvent;

    public delegate void UpdateUpgradeUI(UpgradesData upgradesData);

    public static event UpdateUpgradeUI UpdateUpgradeUIEvent;

    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private Button biggerBaitButton;
    [SerializeField] private Button fishingLineLengthButton;

    [SerializeField] private BiggerBait biggerBait;
    [SerializeField] private FishingLineLength fishingLineLength;

    private void Start()
    {
        biggerBaitButton.onClick.AddListener(delegate { BuyUpgrade(biggerBait); });
        fishingLineLengthButton.onClick.AddListener(delegate { BuyUpgrade(fishingLineLength); });
    }

    private void BuyUpgrade(UpgradesData upgrade)
    {
        if (Money.Instance.MoneyHaving < upgrade.Price)
        {
            return;
        }

        if (TryBuyUpgradesEvent.Invoke(upgrade))
        {
            UpdateUpgradeUIEvent?.Invoke(upgrade);
            Money.Instance.SubtractMoney(upgrade.Price);
            moneyText.text = Money.Instance.MoneyHaving.ToString() + "$";
        }
    }
}
