using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCatalogManager : MonoBehaviour
{    
    [SerializeField] private GameObject fishCatalog;
    
    private bool isCatalogOpen;

    public bool IsCatalogOpen { get { return isCatalogOpen; } }

    private void Start()
    {
        fishCatalog.SetActive(false);
    }

    private void Update()
    {
        if (!FishingRod.Instance.Hook.IsHookOnRod)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenCatalog();
        }
    }

    private void OpenCatalog()
    {
        isCatalogOpen = !isCatalogOpen;
        fishCatalog.SetActive(isCatalogOpen);
    }
}
