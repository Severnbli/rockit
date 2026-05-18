using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Monos
{
    public class InputSystemSelectableInvoker : OnScreenControl, IPointerUpHandler, IPointerDownHandler, 
        IPointerExitHandler, ICancelHandler
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
        
        private bool CanInteract => enabled && _selectable != null && _selectable.interactable;

        private void Enable()
        {
            if (!CanInteract) return;
            
            SendValueToControl(1.0f);
        }

        private void Disable()
        {
            if (!CanInteract) return;
            
            SendValueToControl(0.0f);
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            Disable();
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            Enable();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Disable();
        }

        public void OnCancel(BaseEventData eventData)
        {
            Disable();
        }
    }
}