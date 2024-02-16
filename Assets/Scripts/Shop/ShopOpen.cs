using UnityEngine;
using UnityEngine.UI;

public class ShopOpen : MonoBehaviour
{
    [SerializeField] private Text shopText;
    [SerializeField] private GameObject shop;
    
    private bool isShopOpen;

    public bool IsShopOpen { get { return isShopOpen; } }

    private void Update()
    {
        OpenShop();
    }

    private void OpenShop()
    {
        if (FishingRod.Instance.Hook.IsHookOnRod)
        {
            if (Input.GetKeyDown("p"))
            {
                isShopOpen = !isShopOpen;
                shop.SetActive(isShopOpen);
            }
            shopText.gameObject.SetActive(!isShopOpen);
        }
        else
        {
            isShopOpen = false;
            shop.SetActive(isShopOpen);
            shopText.gameObject.SetActive(isShopOpen);
        }
    }
}
