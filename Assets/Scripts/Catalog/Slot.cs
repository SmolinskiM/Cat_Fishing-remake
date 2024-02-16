using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fishName;
    [SerializeField] private TextMeshProUGUI fishValue;
    [SerializeField] private Image fishSprite;
    
    private FishData fishData;

    public FishData FishData { get { return fishData; } }

    private void Awake()
    {
        CatchingFish.ShowContentSlotEvent += ShowContentSlot;
    }

    private void Start()
    {
        if (FishSaveMeneger.Instance.fishSave.fishDictiosnary[fishData.name])
        {
            ShowContentSlot(fishData);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetUpSlot(FishData fish)
    {
        fishData = fish;
        fishSprite.sprite = fish.FishSprite;
    }

    public void ShowContentSlot(FishData fish)
    {
        if (fish == fishData)
        {
            fishName.text = fish.name;
            fishValue.text = fish.Value.ToString() + "$";
            fishSprite.color = Color.white;
        }
    }
}
 