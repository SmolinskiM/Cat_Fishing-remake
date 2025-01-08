using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShopOpen : MonoBehaviour
{
    [SerializeField] private Text shopText;
    [SerializeField] private GameObject shop;

    [SerializeField] private ActionMediator mediator;
    public bool IsShopOpen { get { return shop.activeSelf; } }

    // InputAction do otwierania sklepu
    private PlayerAction openShopAction;

    private void OnEnable()
    {
        openShopAction = new PlayerAction();
        openShopAction.UI.OpenShop.Enable();
        // Zakładając, że masz "OpenShop" przypisane do akcji w Input Actions
        openShopAction.UI.OpenShop.performed += OpenShop;
    }

    private void OnDisable()
    {
        openShopAction.Disable();
    }

    private void OpenShop(InputAction.CallbackContext context)
    {
        if(!mediator.IsActionAllowed() && !IsShopOpen)
        {
            return;
        }
        mediator.SetActionAllowed(IsShopOpen);
        shop.SetActive(!IsShopOpen);
        shopText.gameObject.SetActive(!IsShopOpen);
    }
}
