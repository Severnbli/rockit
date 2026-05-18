using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Monos
{
    public class InputSystemSelectableInvoker : OnScreenControl, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Selectable _selectable;
        
        [InputControl(layout = "Button")]
        [SerializeField]
        private string _controlPath;

        protected override string controlPathInternal
        {
            get => _controlPath;
            set => _controlPath = value;
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_selectable.interactable) SendValueToControl(0.0f);
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_selectable.interactable) SendValueToControl(1.0f);
        }
    }
}