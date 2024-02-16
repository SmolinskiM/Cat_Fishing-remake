using UnityEngine;
using UnityEngine.UI;

public class TabCatalogMeneger : MonoBehaviour
{
    [SerializeField] private Button tabSmall;
    [SerializeField] private Button tabMedium;
    [SerializeField] private Button tabLarge;
    [SerializeField] private GameObject content;
    
    private Slot[] slots;

    private void Start()
    {
        slots = content.GetComponentsInChildren<Slot>();
        tabSmall.onClick.AddListener(ClickTabSmal);
        tabMedium.onClick.AddListener(ClickTabMedium);
        tabLarge.onClick.AddListener(ClickTabLarge);
        ClickTabSmal();
    }

    private void ClickTabSmal()
    {
        ChangeContent(FishSize.Small);
    }

    private void ClickTabMedium()
    {
        ChangeContent(FishSize.Medium);
    }

    private void ClickTabLarge()
    {
        ChangeContent(FishSize.Large);
    }

    private void ChangeContent(FishSize sizeContent)
    {
        HideContent();
        foreach (Slot slot in slots)
        {
            if(slot.FishData.FishSize == sizeContent)
            {
                slot.Show();
            }
        }
    }

    private void HideContent()
    {
        foreach(Slot slot in slots)
        {
            slot.gameObject.SetActive(false);
        }
    }
}
