// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/playerMovement/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""TestPlayer"",
            ""id"": ""86e68bde-397b-43aa-aef9-6c93411baef6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""46c2951a-d2d7-492b-aa5c-7effbdfc8997"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Choices"",
                    ""type"": ""Button"",
                    ""id"": ""599dd3e4-6130-4b70-8d64-6fe2e7b85341"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""04c1cd38-b836-4b2e-a2ee-93094e40b67a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3f8541c1-3b29-45f7-ba26-0f9af4a692ad"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""4aa4fb57-5ff1-4d36-b8c7-ecc7dc2c2eda"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1fd74a58-1ec6-44c1-9bf1-fe014c2007d7"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Choices"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b45c0341-ad95-4d47-afb0-1d4def9d885e"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Choices"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""089b4310-1fbf-4dd1-86ef-125be7063ae1"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Choices"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5fe83ed-3934-450e-b203-95410b0f2e21"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Choices"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47d8a9d2-bf4a-4b7c-b119-7f4ea98e72c0"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dfab426-83d0-47ae-9558-e4dcde507d04"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7e87a89-40c9-4d1f-bbff-6418b3f49bd6"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": ""InvertVector2(invertY=false)"",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54ff267c-6f80-4f71-a57e-55abf07f6c66"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e9700743-d004-4351-beee-28d299f983b0"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1ceb4b3d-97d9-44e2-897e-81e2e732c9c6"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3f46b6de-4be1-4511-bc26-5ab27e1a1b2a"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c30ab0b3-88c1-452d-a2ff-8333b3eccd31"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e0e65859-0298-4a7e-ad14-a9607c6db816"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""b5d3a583-8e56-498d-b4e8-44fb408d07e2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7d6f02fd-a7d7-4113-88c1-de79caf5fdab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Choices"",
                    ""type"": ""Button"",
                    ""id"": ""6f364760-1666-4f3e-bd2c-8b3cb46954fb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""0db692c0-1fa7-41ff-93d7-994d938653e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8986fd3e-6d46-4ae2-8149-f8f29e0547b7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""2194e941-1b12-4c03-99fd-752476bf56d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9d4b6f9a-db65-4db9-b796-da181f578b0d"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Choices"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e92bd8fb-d86a-4ad9-89e6-3518e8dd627f"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Choices"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01f6206a-b01c-4473-a607-0166a3bd9e98"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Choices"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""309967c1-a564-4f61-acb7-e12d17e6ae9d"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Choices"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d49dd044-9f1e-4dd0-a50a-0eefec117903"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""438837be-8402-4e3a-a32f-5f32ad5b3e0c"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4227a4b7-ec2b-4762-8759-1aa6683ef452"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": ""InvertVector2(invertY=false)"",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e65e965c-eaef-446a-a343-3098cdef6774"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ControllerMove"",
                    ""id"": ""f7fc709d-8bfb-4b3e-8454-90dba387378b"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9ee518c3-3880-4817-8106-94d1bde2a78b"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1530db3a-968d-47e9-96cb-3c08fe7a3c49"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bfd24f63-1da6-4ee0-b31e-57aa14e42fdd"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e34b89ed-9029-4878-8d45-c88afbfd1b45"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e8050b08-db95-48c4-8c08-a53a01cf67fb"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // TestPlayer
        m_TestPlayer = asset.FindActionMap("TestPlayer", throwIfNotFound: true);
        m_TestPlayer_Move = m_TestPlayer.FindAction("Move", throwIfNotFound: true);
        m_TestPlayer_Choices = m_TestPlayer.FindAction("Choices", throwIfNotFound: true);
        m_TestPlayer_Grab = m_TestPlayer.FindAction("Grab", throwIfNotFound: true);
        m_TestPlayer_Interact = m_TestPlayer.FindAction("Interact", throwIfNotFound: true);
        m_TestPlayer_Rotate = m_TestPlayer.FindAction("Rotate", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Choices = m_Player.FindAction("Choices", throwIfNotFound: true);
        m_Player_Grab = m_Player.FindAction("Grab", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
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

    // TestPlayer
    private readonly InputActionMap m_TestPlayer;
    private ITestPlayerActions m_TestPlayerActionsCallbackInterface;
    private readonly InputAction m_TestPlayer_Move;
    private readonly InputAction m_TestPlayer_Choices;
    private readonly InputAction m_TestPlayer_Grab;
    private readonly InputAction m_TestPlayer_Interact;
    private readonly InputAction m_TestPlayer_Rotate;
    public struct TestPlayerActions
    {
        private @InputMaster m_Wrapper;
        public TestPlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TestPlayer_Move;
        public InputAction @Choices => m_Wrapper.m_TestPlayer_Choices;
        public InputAction @Grab => m_Wrapper.m_TestPlayer_Grab;
        public InputAction @Interact => m_Wrapper.m_TestPlayer_Interact;
        public InputAction @Rotate => m_Wrapper.m_TestPlayer_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_TestPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestPlayerActions set) { return set.Get(); }
        public void SetCallbacks(ITestPlayerActions instance)
        {
            if (m_Wrapper.m_TestPlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnMove;
                @Choices.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnChoices;
                @Choices.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnChoices;
                @Choices.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnChoices;
                @Grab.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnGrab;
                @Interact.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnInteract;
                @Rotate.started -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_TestPlayerActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_TestPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Choices.started += instance.OnChoices;
                @Choices.performed += instance.OnChoices;
                @Choices.canceled += instance.OnChoices;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public TestPlayerActions @TestPlayer => new TestPlayerActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Choices;
    private readonly InputAction m_Player_Grab;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Rotate;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Choices => m_Wrapper.m_Player_Choices;
        public InputAction @Grab => m_Wrapper.m_Player_Grab;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Choices.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoices;
                @Choices.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoices;
                @Choices.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoices;
                @Grab.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrab;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Choices.started += instance.OnChoices;
                @Choices.performed += instance.OnChoices;
                @Choices.canceled += instance.OnChoices;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface ITestPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnChoices(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnChoices(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
