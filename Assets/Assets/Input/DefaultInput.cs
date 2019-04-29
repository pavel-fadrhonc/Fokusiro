// GENERATED AUTOMATICALLY FROM 'Assets/Input/DefaultInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Utilities;

public class DefaultInput : IInputActionCollection
{
    private InputActionAsset asset;
    public DefaultInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""cc2c9fb5-cbe4-44db-a574-0268f6ea6aed"",
            ""actions"": [
                {
                    ""name"": ""AttackRight"",
                    ""id"": ""d098b6c6-c96f-4357-aae6-94bbc5477d1a"",
                    ""expectedControlLayout"": ""Key"",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""bindings"": []
                },
                {
                    ""name"": ""AttackLeft"",
                    ""id"": ""01ee1c80-bc77-4638-b415-4dc5d420e2a2"",
                    ""expectedControlLayout"": ""Key"",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""bindings"": []
                },
                {
                    ""name"": ""AttackTop"",
                    ""id"": ""ab74c4c3-c151-48fa-98cc-381ca7e42b0c"",
                    ""expectedControlLayout"": ""Key"",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""01cd5d45-7956-4690-896d-06e5ea51b568"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Default"",
                    ""action"": ""AttackRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""1a1dae62-ee7d-4519-a048-e587676afbed"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Default"",
                    ""action"": ""AttackRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""48272478-82bf-4456-b2fe-2c5497fc6082"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Default"",
                    ""action"": ""AttackLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""bc8d4bb4-2f70-4673-a10b-05350490002c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Default"",
                    ""action"": ""AttackLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""7e8ee02e-0250-4c90-977f-c1506127a863"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Default"",
                    ""action"": ""AttackTop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""58114b7a-c0f4-453c-bc2c-594790633bf8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Default"",
                    ""action"": ""AttackTop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Default"",
            ""basedOn"": """",
            ""bindingGroup"": ""Default"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_AttackRight = m_Player.GetAction("AttackRight");
        m_Player_AttackLeft = m_Player.GetAction("AttackLeft");
        m_Player_AttackTop = m_Player.GetAction("AttackTop");
    }
    ~DefaultInput()
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
    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }
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
    // Player
    private InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private InputAction m_Player_AttackRight;
    private InputAction m_Player_AttackLeft;
    private InputAction m_Player_AttackTop;
    public struct PlayerActions
    {
        private DefaultInput m_Wrapper;
        public PlayerActions(DefaultInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @AttackRight { get { return m_Wrapper.m_Player_AttackRight; } }
        public InputAction @AttackLeft { get { return m_Wrapper.m_Player_AttackLeft; } }
        public InputAction @AttackTop { get { return m_Wrapper.m_Player_AttackTop; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                AttackRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRight;
                AttackRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRight;
                AttackRight.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRight;
                AttackLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLeft;
                AttackLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLeft;
                AttackLeft.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLeft;
                AttackTop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackTop;
                AttackTop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackTop;
                AttackTop.cancelled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackTop;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                AttackRight.started += instance.OnAttackRight;
                AttackRight.performed += instance.OnAttackRight;
                AttackRight.cancelled += instance.OnAttackRight;
                AttackLeft.started += instance.OnAttackLeft;
                AttackLeft.performed += instance.OnAttackLeft;
                AttackLeft.cancelled += instance.OnAttackLeft;
                AttackTop.started += instance.OnAttackTop;
                AttackTop.performed += instance.OnAttackTop;
                AttackTop.cancelled += instance.OnAttackTop;
            }
        }
    }
    public PlayerActions @Player
    {
        get
        {
            return new PlayerActions(this);
        }
    }
    private int m_DefaultSchemeIndex = -1;
    public InputControlScheme DefaultScheme
    {
        get
        {
            if (m_DefaultSchemeIndex == -1) m_DefaultSchemeIndex = asset.GetControlSchemeIndex("Default");
            return asset.controlSchemes[m_DefaultSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnAttackRight(InputAction.CallbackContext context);
        void OnAttackLeft(InputAction.CallbackContext context);
        void OnAttackTop(InputAction.CallbackContext context);
    }
}
