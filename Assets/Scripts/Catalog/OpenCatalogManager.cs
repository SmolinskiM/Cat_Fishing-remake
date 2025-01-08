using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenCatalogManager : MonoBehaviour
{    
    [SerializeField] private GameObject fishCatalog;

    [SerializeField] private ActionMediator mediator;

    public bool IsCatalogOpen { get { return fishCatalog.activeSelf; } }

    private PlayerAction inputActions;

    private void Awake()
    {
        inputActions = new PlayerAction();
        inputActions.UI.OpenCataloge.Enable();
        inputActions.UI.OpenCataloge.performed += OpenCatalog;
    }

    private void Start()
    {
        fishCatalog.SetActive(false);
    }

    private void OpenCatalog(InputAction.CallbackContext context)
    {
        if (!mediator.IsActionAllowed() && !IsCatalogOpen)
        {
            return;
        }
        mediator.SetActionAllowed(IsCatalogOpen);
        fishCatalog.SetActive(!IsCatalogOpen);
    }
}
