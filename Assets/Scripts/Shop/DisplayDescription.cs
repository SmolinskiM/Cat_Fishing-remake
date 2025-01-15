using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayDescription: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Text descriptionText;
    [SerializeField] private Image descriptionBg;
    [SerializeField] private UpgradesData upgrades;
    
    private bool isMouseOn;
    private Vector3 ofset;
    private RectTransform rectTransform;

    private PlayerAction mousePositionAction;

    public bool IsMouseOn { get { return isMouseOn; } }

    private void Awake()
    {
        mousePositionAction = new PlayerAction();
        mousePositionAction.UI.MousePosition.Enable();
    }

    private void Start()
    {
        rectTransform = descriptionBg.GetComponent<RectTransform>();
        ofset = new Vector3(descriptionBg.GetComponent<RectTransform>().rect.width, 0, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOn = false;
    }

    private void Update()
    {
        if(!isMouseOn)
        {
            return;
        }
        TextOnMouse();
    }

    private void TextOnMouse()
    {
        descriptionText.text = upgrades.Description;
        ofset = new Vector3(rectTransform.rect.width, 0, 0);
        Vector3 mousePosition = mousePositionAction.UI.MousePosition.ReadValue<Vector2>();
        descriptionBg.transform.position = mousePosition + ofset;
    }
}
