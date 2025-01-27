//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem.inputactions
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

public partial class @InputSystem: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Player map"",
            ""id"": ""8475d2d9-ca24-4781-827f-75a8d9ca1569"",
            ""actions"": [
                {
                    ""name"": ""Direct"",
                    ""type"": ""Value"",
                    ""id"": ""ca1eb3e0-9ca9-4d3a-82af-24e3760da6e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""19e15707-dcb5-41d2-903d-ff1b0323f134"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD input"",
                    ""id"": ""810a01af-bc36-45f1-9c49-022d982dfa42"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direct"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""51ff7c17-5592-4c89-8138-d8561bda4da2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""62716aed-33a0-40b6-86e6-f3ee5b7213a2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direct"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""88135dcc-ac66-419a-96d3-90f7440c0864"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player map
        m_Playermap = asset.FindActionMap("Player map", throwIfNotFound: true);
        m_Playermap_Direct = m_Playermap.FindAction("Direct", throwIfNotFound: true);
        m_Playermap_Jump = m_Playermap.FindAction("Jump", throwIfNotFound: true);
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

    // Player map
    private readonly InputActionMap m_Playermap;
    private List<IPlayermapActions> m_PlayermapActionsCallbackInterfaces = new List<IPlayermapActions>();
    private readonly InputAction m_Playermap_Direct;
    private readonly InputAction m_Playermap_Jump;
    public struct PlayermapActions
    {
        private @InputSystem m_Wrapper;
        public PlayermapActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Direct => m_Wrapper.m_Playermap_Direct;
        public InputAction @Jump => m_Wrapper.m_Playermap_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Playermap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayermapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayermapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayermapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayermapActionsCallbackInterfaces.Add(instance);
            @Direct.started += instance.OnDirect;
            @Direct.performed += instance.OnDirect;
            @Direct.canceled += instance.OnDirect;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IPlayermapActions instance)
        {
            @Direct.started -= instance.OnDirect;
            @Direct.performed -= instance.OnDirect;
            @Direct.canceled -= instance.OnDirect;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IPlayermapActions instance)
        {
            if (m_Wrapper.m_PlayermapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayermapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayermapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayermapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayermapActions @Playermap => new PlayermapActions(this);
    public interface IPlayermapActions
    {
        void OnDirect(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
