using System;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Types
{
    public class BaseWindow<TWindow, TConfig> : IInitializable
        where TWindow : MonoBaseWindow
        where TConfig : BaseWindowConfig<TConfig>
    {
        private readonly MonoBaseWindow _mbWindow;
        private readonly BaseWindowConfig<TConfig> _bwConfig;

        protected readonly TweenPipelineRunner TpRunner;
        
        public event Action OnOpen;
        public event Action OnClose;

        public bool Opened { get; private set; }

        public BaseWindow(TWindow window, BaseWindowConfig<TConfig> bwConfig, TweenPipelineRunner tpRunner)
        {
            _mbWindow = window;
            _bwConfig = bwConfig;
            TpRunner = tpRunner;
        }
        
        public virtual void Initialize()
        {
            TpRunner.CacheRun(_bwConfig.BodyOpen, _mbWindow.Body);
            TpRunner.CacheRun(_bwConfig.BodyClose, _mbWindow.Body);
        }
        
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

        protected virtual async UniTask PlayCloseAnimation()
        {
            await PlayCloseBodyAnimation();
        }

        protected virtual async UniTask PlayOpenBodyAnimation()
        {
            await TpRunner.Run(_bwConfig.BodyOpen, _mbWindow.Body, true);
        }

        protected virtual async UniTask PlayCloseBodyAnimation()
        {
            await TpRunner.Run(_bwConfig.BodyClose, _mbWindow.Body, true);
        }
    }
}