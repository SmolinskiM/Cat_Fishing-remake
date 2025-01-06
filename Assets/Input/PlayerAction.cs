//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/PlayerAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerAction"",
    ""maps"": [
        {
            ""name"": ""Rod"",
            ""id"": ""b3370059-b24f-477c-a252-104719c21cf0"",
            ""actions"": [
                {
                    ""name"": ""ThrowHook"",
                    ""type"": ""Value"",
                    ""id"": ""41c5502a-81fa-46ca-8eba-0f903ea7b300"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RollingUp"",
                    ""type"": ""Value"",
                    ""id"": ""0bcf68ef-646d-4d94-aae7-3f20794851d2"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FightWithFish"",
                    ""type"": ""Value"",
                    ""id"": ""b60ccea7-c471-46ec-935e-2ca71d3198b3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c211d161-10dd-4792-81a1-de9ba02a3ba1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowHook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8389e807-945d-4020-aa02-fa97378fa73b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollingUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""A/D Move"",
                    ""id"": ""9353b908-f809-424e-9d8b-6af0e017f98d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FightWithFish"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""07dcfeac-2640-4f2f-b506-9e560cbec828"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FightWithFish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""489b0bc9-1d6e-4dd7-903d-9911980179e7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FightWithFish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left/Right Move"",
                    ""id"": ""e49f6411-5768-488d-ae16-130cf1249282"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FightWithFish"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""53fe8884-79ab-4c8a-a253-30d7bf4bcec2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FightWithFish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""05338526-94bf-4ad0-bcc3-33b137081e8f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FightWithFish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""56d71515-79c6-451a-9cb6-f7a800775110"",
            ""actions"": [
                {
                    ""name"": ""OpenCataloge"",
                    ""type"": ""Button"",
                    ""id"": ""10882122-28f2-45fe-b2e7-119e90d59fe9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenShop"",
                    ""type"": ""Button"",
                    ""id"": ""c8c559cc-0436-4927-830e-5cb902d92221"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a3144b9-87cd-4148-8932-64d96cbecd73"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenCataloge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c37a1b07-d2cc-4bbf-99c6-75c3dd60c8b6"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenShop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Rod
        m_Rod = asset.FindActionMap("Rod", throwIfNotFound: true);
        m_Rod_ThrowHook = m_Rod.FindAction("ThrowHook", throwIfNotFound: true);
        m_Rod_RollingUp = m_Rod.FindAction("RollingUp", throwIfNotFound: true);
        m_Rod_FightWithFish = m_Rod.FindAction("FightWithFish", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_OpenCataloge = m_UI.FindAction("OpenCataloge", throwIfNotFound: true);
        m_UI_OpenShop = m_UI.FindAction("OpenShop", throwIfNotFound: true);
    }

    ~@PlayerAction()
    {
        UnityEngine.Debug.Assert(!m_Rod.enabled, "This will cause a leak and performance issues, PlayerAction.Rod.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_UI.enabled, "This will cause a leak and performance issues, PlayerAction.UI.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Rod
    private readonly InputActionMap m_Rod;
    private List<IRodActions> m_RodActionsCallbackInterfaces = new List<IRodActions>();
    private readonly InputAction m_Rod_ThrowHook;
    private readonly InputAction m_Rod_RollingUp;
    private readonly InputAction m_Rod_FightWithFish;
    public struct RodActions
    {
        private @PlayerAction m_Wrapper;
        public RodActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @ThrowHook => m_Wrapper.m_Rod_ThrowHook;
        public InputAction @RollingUp => m_Wrapper.m_Rod_RollingUp;
        public InputAction @FightWithFish => m_Wrapper.m_Rod_FightWithFish;
        public InputActionMap Get() { return m_Wrapper.m_Rod; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RodActions set) { return set.Get(); }
        public void AddCallbacks(IRodActions instance)
        {
            if (instance == null || m_Wrapper.m_RodActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RodActionsCallbackInterfaces.Add(instance);
            @ThrowHook.started += instance.OnThrowHook;
            @ThrowHook.performed += instance.OnThrowHook;
            @ThrowHook.canceled += instance.OnThrowHook;
            @RollingUp.started += instance.OnRollingUp;
            @RollingUp.performed += instance.OnRollingUp;
            @RollingUp.canceled += instance.OnRollingUp;
            @FightWithFish.started += instance.OnFightWithFish;
            @FightWithFish.performed += instance.OnFightWithFish;
            @FightWithFish.canceled += instance.OnFightWithFish;
        }

        private void UnregisterCallbacks(IRodActions instance)
        {
            @ThrowHook.started -= instance.OnThrowHook;
            @ThrowHook.performed -= instance.OnThrowHook;
            @ThrowHook.canceled -= instance.OnThrowHook;
            @RollingUp.started -= instance.OnRollingUp;
            @RollingUp.performed -= instance.OnRollingUp;
            @RollingUp.canceled -= instance.OnRollingUp;
            @FightWithFish.started -= instance.OnFightWithFish;
            @FightWithFish.performed -= instance.OnFightWithFish;
            @FightWithFish.canceled -= instance.OnFightWithFish;
        }

        public void RemoveCallbacks(IRodActions instance)
        {
            if (m_Wrapper.m_RodActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRodActions instance)
        {
            foreach (var item in m_Wrapper.m_RodActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RodActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RodActions @Rod => new RodActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_OpenCataloge;
    private readonly InputAction m_UI_OpenShop;
    public struct UIActions
    {
        private @PlayerAction m_Wrapper;
        public UIActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenCataloge => m_Wrapper.m_UI_OpenCataloge;
        public InputAction @OpenShop => m_Wrapper.m_UI_OpenShop;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @OpenCataloge.started += instance.OnOpenCataloge;
            @OpenCataloge.performed += instance.OnOpenCataloge;
            @OpenCataloge.canceled += instance.OnOpenCataloge;
            @OpenShop.started += instance.OnOpenShop;
            @OpenShop.performed += instance.OnOpenShop;
            @OpenShop.canceled += instance.OnOpenShop;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @OpenCataloge.started -= instance.OnOpenCataloge;
            @OpenCataloge.performed -= instance.OnOpenCataloge;
            @OpenCataloge.canceled -= instance.OnOpenCataloge;
            @OpenShop.started -= instance.OnOpenShop;
            @OpenShop.performed -= instance.OnOpenShop;
            @OpenShop.canceled -= instance.OnOpenShop;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IRodActions
    {
        void OnThrowHook(InputAction.CallbackContext context);
        void OnRollingUp(InputAction.CallbackContext context);
        void OnFightWithFish(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnOpenCataloge(InputAction.CallbackContext context);
        void OnOpenShop(InputAction.CallbackContext context);
    }
}