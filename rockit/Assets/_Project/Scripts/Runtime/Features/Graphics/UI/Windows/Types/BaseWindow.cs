using System;
using System.Threading;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Monos;
using _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Animations;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Types
{
    public class BaseWindow<TWindow, TConfig> 
        where TWindow : MonoBaseWindow
        where TConfig : BaseWindowConfig<TConfig>
    {
        private readonly MonoBaseWindow _mbWindow;
        private readonly BaseWindowConfig<TConfig> _bwConfig;

        protected readonly CancellationToken Ct;
        
        public event Action OnOpen;
        public event Action OnClose;

        public bool Opened { get; private set; }

        public BaseWindow(TWindow window, BaseWindowConfig<TConfig> bwConfig, CancellationToken ct)
        {
            _mbWindow = window;
            _bwConfig = bwConfig;
            Ct = ct;
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
            await _mbWindow.Body.transform.ScaleTween(_bwConfig.BodyOpen).ToUniTask(cancellationToken: Ct);
        }

        protected virtual async UniTask PlayCloseBodyAnimation()
        {
            await _mbWindow.Body.transform.ScaleTween(_bwConfig.BodyClose).ToUniTask(cancellationToken: Ct);
        }
    }
}