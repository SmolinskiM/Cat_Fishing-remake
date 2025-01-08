using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DialogueEditor;

public class CatchingFish: MonoBehaviour
{
    public delegate void ShowContentSlot(FishData fishData);

    public static event ShowContentSlot ShowContentSlotEvent;

    [SerializeField] private GameObject whatToDoWithFish;
    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private Button makeBait;
    [SerializeField] private Button sellFish;
    [SerializeField] private Button goToCity;

    [SerializeField] private FishSpawner fishSpawner;

    [SerializeField] private FishData goldFish;

    [SerializeField] private NPCConversation npcConversation;

    private bool isDialogOpened;

    private Fish fish;
    private FishingRod fishingRod;

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

        if (fishingRod.Hook.IsHookOnRod && fishingRod.Hook.IsFishOnHook)
        {
            fish = fishingRod.Hook.gameObject.GetComponentInChildren<Fish>();

            if(fish.FishData == goldFish)
            {
                if(isDialogOpened)
                {
                    return;
                }

                ConversationManager.Instance.StartConversation(npcConversation);
                isDialogOpened = true;
            }
            else
            {
                whatToDoWithFish.SetActive(true);
            }
        }
        else
        {
            fish = fishingRod.Hook.gameObject.GetComponentInChildren<Fish>();
            whatToDoWithFish.SetActive(false);
        }
    }

    public void SellFish()
    {
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

    public void DestroyFish()
    {
        fish = fishingRod.Hook.gameObject.GetComponentInChildren<Fish>();
        fishingRod.Hook.IsFishOnHook = false;
        FishSaveMeneger.Instance.SaveData(fish.FishData);
        ShowContentSlotEvent?.Invoke(fish.FishData);

        if(fish.FishData == goldFish)
        {
            goToCity.gameObject.SetActive(true);
            fishSpawner.IsPossibleToSpawnGoldFish = false;
            isDialogOpened = false;
        }

        fishingRod.Mediator.SetActionAllowed(true);
        fish.DestoyFish();
        //Destroy(fish.gameObject);
    }

    public void LetGoGoldFish()
    {
        fishingRod.Hook.IsFishOnHook = false;
        Money.Instance.AddMoney(1000);
        moneyText.text = Money.Instance.MoneyHaving.ToString() + "$";
        fishSpawner.IsPossibleToSpawnGoldFish = false;
        Destroy(fish.gameObject);
        isDialogOpened = false;
    }
}
