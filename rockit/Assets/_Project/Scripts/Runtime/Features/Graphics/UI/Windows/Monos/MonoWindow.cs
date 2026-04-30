using System;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Animations;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos
{
    public class MonoWindow : MonoBehaviour
    {
        [SerializeField] protected GameObject Body;
        [SerializeField] protected WindowBodyConfig BodyConfig;
        
        public event Action OnOpen;
        public event Action OnClose;

        public bool Opened { get; private set; }

        public async UniTask Open()
        {
            await PlayOpenAnimation();
            OnOpen?.Invoke();
            Opened = true;
        }

        public async UniTask Close()
        {
            await PlayCloseAnimation();
            OnClose?.Invoke();
            Opened = false;
        }

        protected virtual async UniTask PlayOpenAnimation()
        {
            await PlayOpenBodyAnimation();
        }

        protected virtual async UniTask PlayOpenBodyAnimation()
        {
            await Body.transform.ScaleTween(BodyConfig.OpenSetting)
                .ToUniTask(cancellationToken: destroyCancellationToken);
        }

        protected virtual async UniTask PlayCloseAnimation()
        {
            await PlayCloseBodyAnimation();
        }

        protected virtual async UniTask PlayCloseBodyAnimation()
        {
            await Body.transform.ScaleTween(BodyConfig.CloseSettings)
                .ToUniTask(cancellationToken: destroyCancellationToken);
        }
    }
}