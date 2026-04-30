using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos
{
    public class MonoWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        
        public event Action OnOpen;
        public event Action OnClose;

        public bool Opened { get; private set; }

        public async UniTask Open()
        {
            await PlayOpenAnimation();
            OnOpen?.Invoke();
            Opened = true;
        }

        protected virtual async UniTask PlayOpenAnimation() {}

        public async UniTask Close()
        {
            await PlayCloseAnimation();
            OnClose?.Invoke();
            Opened = false;
        }

        protected virtual async UniTask PlayCloseAnimation() {}
    }
}