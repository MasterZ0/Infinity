using Infinity.Puzzle;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infinity.Player {

    /// <summary>
    /// Send touch events
    /// </summary>
    public class MobileInputs {

        #region Events
        public event Action<Vector2> OnStartTouch;
        public event Action<Vector2> OnEndTouch;
        public event Action<Vector2> OnMove;
        #endregion

        #region Properties and variables
        private readonly Controls controls;
        private Camera Camera => CameraController.MainCamera;
        #endregion

        #region Public
        public MobileInputs(bool startEnable = true) {
            controls = new Controls();
            controls.Mobile.PrimaryDelta.performed += Delta;
            controls.Mobile.PrimaryTouch.started += StartTouchPrimary;
            controls.Mobile.PrimaryTouch.canceled += EndTouchPrimary;

            if (startEnable) {
                controls.Enable();
            }
        }

        public void SetActive(bool active) {
            if (active) {
                controls.Enable();
            }
            else {
                controls.Disable();
            }
        }

        public void Dispose() {
            controls.Mobile.PrimaryDelta.performed -= Delta;
            controls.Mobile.PrimaryTouch.started -= StartTouchPrimary;
            controls.Mobile.PrimaryTouch.canceled -= EndTouchPrimary;
            controls.Dispose();

        }
        #endregion

        #region Private Methods
        private void StartTouchPrimary(InputAction.CallbackContext context) {
            OnStartTouch(GetWorldPosition());
        }

        private void EndTouchPrimary(InputAction.CallbackContext context) {
            OnEndTouch(GetWorldPosition());
        }
        private void Delta(InputAction.CallbackContext context) {
            OnMove(GetWorldPosition());
        }

        private Vector2 GetWorldPosition() {
            Vector2 fingerPosition = controls.Mobile.PrimaryPosition.ReadValue<Vector2>();
            return Camera.ScreenToWorldPoint(fingerPosition);
        }
        #endregion
    }
}