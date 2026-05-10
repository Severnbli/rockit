using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using _Project.Scripts.Runtime.Core.Infrastructure.Shared.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos
{
    public class MonoBaseWindow<TConfig> : OpenableClosable, IInitializable 
        where TConfig : BaseWindowConfig
    {
        [SerializeField] protected TConfig Config;
        [SerializeField] protected GameObject Body;

        protected ITweenPipelineRunner TpRunner;
        
        public event Action OnOpen;
        public event Action OnClose;
        public bool Opened { get; private set; }

        [Inject]
        private void Construct(ITweenPipelineRunner tpRunner)
        {
            TpRunner = tpRunner;
        }
        
        public virtual void Initialize()
        {
            TpRunner.CacheRun(Config.BodyOpen, Body);
            TpRunner.CacheRun(Config.BodyClose, Body);
        }

        public override void Open()
        {
            OpenAwait().Forget();
        }
        
        public async UniTask OpenAwait()
        {
            gameObject.SetActive(true);
            await PlayOpenAnimation();
            OnOpen?.Invoke();
            Opened = true;
        }

        public override void Close()
        {
            CloseAwait().Forget();
        }

        public async UniTask CloseAwait()
        {
            await PlayCloseAnimation();
            OnClose?.Invoke();
            Opened = false;
            gameObject.SetActive(false);
        }

        protected virtual async UniTask PlayOpenAnimation()
        {
            await PlayOpenBodyAnimation();
        }

        protected virtual async UniTask PlayCloseAnimation()
        {
            await PlayCloseBodyAnimation();
        }

        protected virtual async UniTask PlayOpenBodyAnimation()
        {
            await TpRunner.Run(Config.BodyOpen, Body, true);
        }

        protected virtual async UniTask PlayCloseBodyAnimation()
        {
            await TpRunner.Run(Config.BodyClose, Body, true);
        }
    }
}