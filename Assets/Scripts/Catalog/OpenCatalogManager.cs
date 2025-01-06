using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenCatalogManager : MonoBehaviour
{    
    [SerializeField] private GameObject fishCatalog;
    
    private bool isCatalogOpen;

    public bool IsCatalogOpen { get { return isCatalogOpen; } }

    private PlayerAction inputActions;

    private void Awake()
    {
        inputActions = new PlayerAction();
        inputActions.UI.Enable();
        inputActions.UI.OpenCataloge.performed += OpenCatalog;
    }

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
    }

    private void OpenCatalog(InputAction.CallbackContext context)
    {
        if (!FishingRod.Instance.Hook.IsHookOnRod)
        {
            return;
        }

        isCatalogOpen = !isCatalogOpen;
        fishCatalog.SetActive(isCatalogOpen);
    }
}
