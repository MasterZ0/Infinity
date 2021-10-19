// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/TouchInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Infinity.Player {
    public class @TouchInputs : IInputActionCollection, IDisposable {
        public InputActionAsset asset { get; }
        public @TouchInputs() {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchInputs"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""2cffd283-611e-4bb3-b413-70e3d917f19f"",
            ""actions"": [
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""35d69b17-1ebf-40a2-9aaf-2c8373451eff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""8aa3084e-957c-4b07-a452-fff05cbe6502"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""93e9002d-9e73-48ff-8944-174960329cf3"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c28a83a-d10f-4478-b2ad-99ee2e9a6684"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Touch
            m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
            m_Touch_TouchPress = m_Touch.FindAction("TouchPress", throwIfNotFound: true);
            m_Touch_TouchPosition = m_Touch.FindAction("TouchPosition", throwIfNotFound: true);
        }

        public void Dispose() {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action) {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator() {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Enable() {
            asset.Enable();
        }

        public void Disable() {
            asset.Disable();
        }

        // Touch
        private readonly InputActionMap m_Touch;
        private ITouchActions m_TouchActionsCallbackInterface;
        private readonly InputAction m_Touch_TouchPress;
        private readonly InputAction m_Touch_TouchPosition;
        public struct TouchActions {
            private @TouchInputs m_Wrapper;
            public TouchActions(@TouchInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @TouchPress => m_Wrapper.m_Touch_TouchPress;
            public InputAction @TouchPosition => m_Wrapper.m_Touch_TouchPosition;
            public InputActionMap Get() { return m_Wrapper.m_Touch; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
            public void SetCallbacks(ITouchActions instance) {
                if (m_Wrapper.m_TouchActionsCallbackInterface != null) {
                    @TouchPress.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPress.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPress.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                    @TouchPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                    @TouchPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                }
                m_Wrapper.m_TouchActionsCallbackInterface = instance;
                if (instance != null) {
                    @TouchPress.started += instance.OnTouchPress;
                    @TouchPress.performed += instance.OnTouchPress;
                    @TouchPress.canceled += instance.OnTouchPress;
                    @TouchPosition.started += instance.OnTouchPosition;
                    @TouchPosition.performed += instance.OnTouchPosition;
                    @TouchPosition.canceled += instance.OnTouchPosition;
                }
            }
        }
        public TouchActions @Touch => new TouchActions(this);
        public interface ITouchActions {
            void OnTouchPress(InputAction.CallbackContext context);
            void OnTouchPosition(InputAction.CallbackContext context);
        }
    }
}
