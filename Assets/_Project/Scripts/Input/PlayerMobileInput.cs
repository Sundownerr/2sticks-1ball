using System;
using System.Collections.Generic;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SDW.Input
{
    public class PlayerMobileInput : MonoBehaviour, IMobileInput
    {
        [SerializeField] private bool _ignoreUI;
        private readonly List<RaycastResult> _uiRaycastResults = new();
        private InputActions _inputActions;
        private InputActions.MobileActions _mobile;

        private void Start()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();

            _mobile = _inputActions.Mobile;
        }

        private void Update()
        {
            PointerDelta = _mobile.PointerDelta.ReadValue<Vector2>();
            PointerDeltaNormalized = _mobile.PointerDeltaNormalized.ReadValue<Vector2>();
            PointerPosition = _mobile.PointerPosition.ReadValue<Vector2>();
            PointerPositionNormalized = _mobile.PointerPositionNormalized.ReadValue<Vector2>();

            if (_mobile.Tap.WasPerformedThisFrame() && !IsPointerOverUI(PointerPosition))
            {
                TapStart?.Invoke();
                IsPressed = true;
            }

            if (_mobile.Tap.WasReleasedThisFrame())
            {
                TapEnd?.Invoke();
                IsPressed = false;
            }
        }

        public Vector2 PointerDelta { get; private set; }

        public Vector2 PointerPosition { get; private set; }

        public Vector2 PointerPositionNormalized { get; private set; }

        public Vector2 PointerDeltaNormalized { get; private set; }

        public event Action TapStart;
        public event Action TapEnd;

        public bool IsPressed { get; set; }

        public bool IsPointerOverUI(Vector2 pointerPosition)
        {
            if (_ignoreUI)
            {
                return false;
            }
            
            var pointerEventData = new PointerEventData(EventSystem.current) {
                position = pointerPosition,
            };

            EventSystem.current.RaycastAll(pointerEventData, _uiRaycastResults);
            return _uiRaycastResults.Count > 0;
        }
    }
}