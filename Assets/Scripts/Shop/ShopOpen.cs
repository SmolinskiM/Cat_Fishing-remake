using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShopOpen : MonoBehaviour
{
    [SerializeField] private Text shopText;
    [SerializeField] private GameObject shop;

    private bool isShopOpen;

    public bool IsShopOpen { get { return isShopOpen; } }

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
        if(!FishingRod.Instance.Hook.IsHookOnRod)
        {
            return;
        }

        isShopOpen = !isShopOpen;
        shop.SetActive(isShopOpen);
        shopText.gameObject.SetActive(!isShopOpen);
    }
}
