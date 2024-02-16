using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatchingFish: MonoBehaviour
{
    public delegate void ShowContentSlot(FishData fishData);

    public static event ShowContentSlot ShowContentSlotEvent;

    private Fish fish;
    private FishingRod fishingRod;

    [SerializeField] private GameObject whatToDoWithFish;
    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private Button makeBait;
    [SerializeField] private Button sellFish;

    private void Start()
    {
        makeBait.onClick.AddListener(MakeBait);
        sellFish.onClick.AddListener(SellFish);
        fishingRod = GetComponent<FishingRod>();
        moneyText.text = Money.Instance.MoneyHaving.ToString() + "$";
    }

    private void Update()
    {
        moneyText.gameObject.SetActive(fishingRod.Hook.IsHookOnRod);

        if(fishingRod.Hook.IsHookOnRod && fishingRod.Hook.IsFishOnHook)
        {
            whatToDoWithFish.SetActive(true);
        }
        else
        {
            whatToDoWithFish.SetActive(false);
        }
    }

    public void SellFish()
    {
        fish = fishingRod.Hook.gameObject.GetComponentInChildren<Fish>();
        Money.Instance.AddMoney(fish.FishData.Value);
        moneyText.text = Money.Instance.MoneyHaving.ToString() + "$";
        DestroyFish();
    }

    public void MakeBait()
    {
        fish = fishingRod.Hook.gameObject.GetComponentInChildren<Fish>();
        fishingRod.Hook.Bait.ChangeSizeBait((int)fish.FishData.FishSize + 1);
        DestroyFish();
    }

    private void DestroyFish()
    {
        fishingRod.Hook.IsFishOnHook = false;
        FishSaveMeneger.Instance.SaveData(fish.FishData);
        ShowContentSlotEvent?.Invoke(fish.FishData);
        Destroy(fish.gameObject);
    }
}
