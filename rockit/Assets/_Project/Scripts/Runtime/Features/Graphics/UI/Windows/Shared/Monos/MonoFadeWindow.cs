using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Monos
{
    public class MonoFadeWindow<TConfig> : MonoBaseWindow<TConfig> 
        where TConfig : FadeWindowConfig
    {
        [SerializeField] protected GameObject Fade;
        
        public override void Initialize()
        {
            base.Initialize();
            
            TpRunner.CacheRun(Config.FadeOpen, Fade);
            TpRunner.CacheRun(Config.FadeClose, Fade);
        }
        
        protected override UniTask PlayOpenAnimation()
        {
            return UniTask.WhenAll(
                base.PlayOpenAnimation(),
                PlayFadeOpenAnimation()
            );
        }

        protected override UniTask PlayCloseAnimation()
        {
            return UniTask.WhenAll(
                base.PlayCloseAnimation(),
                PlayFadeCloseAnimation()
            );
        }

        protected virtual async UniTask PlayFadeOpenAnimation()
        {
            await TpRunner.Run(Config.FadeOpen, Fade, true);
        }

        protected virtual async UniTask PlayFadeCloseAnimation()
        {
            await TpRunner.Run(Config.FadeClose, Fade, true);
        }
    }
}