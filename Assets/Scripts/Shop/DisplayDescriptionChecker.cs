using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayDescriptionChecker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image descriptionBg;

    private bool isDescriptionVisible;

    private DisplayDescription[] displayDescriptions;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isDescriptionVisible = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isDescriptionVisible = false;
    }

    private void Start()
    {
        displayDescriptions = GetComponentsInChildren<DisplayDescription>();
    }

    private void Update()
    {
        descriptionBg.gameObject.SetActive(isDescriptionVisible);
    }
}
