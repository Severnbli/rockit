using System.Collections.Generic;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Configs;
using _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Shared.Monos;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Windows.Scenes.Game.Monos
{
    public class LevelCompletedWindow : MonoFadeWindow<LevelCompletedWindowConfig>
    {
        [SerializeField] private GameObject _starsContainer;
        [SerializeField] private GameObject _coinsContainer;
        [SerializeField] private GameObject _buttons;
        
        public GameObject StarsContainer => _starsContainer;
        public GameObject CoinsContainer => _coinsContainer;
        public GameObject Buttons => _buttons;
     
        public HashSet<AnimatableStarIcon> EarnedStars { get; protected set; } = new ();
        public HashSet<CoinIcon> CollectedCoins { get; protected set; } = new ();

        protected override async UniTask PlayOpenAnimation()
        {
            await base.PlayOpenAnimation();
            await PlayStarsAnimation();
            await PlayCoinsAnimation();
            
            _buttons.SetActive(true);
            await TpRunner.Run(Config.ButtonsOpen, _buttons);
        }

        private async UniTask PlayStarsAnimation()
        {
            foreach (var star in EarnedStars)
            {
                star.Open();
                await TpRunner.Run(Config.StarsAppear, star.gameObject);
            }
        }

        private async UniTask PlayCoinsAnimation()
        {
            foreach (var coin in CollectedCoins)
            {
                coin.gameObject.SetActive(true);
                await TpRunner.Run(Config.CoinsAppear, coin.gameObject);
            }
        }

        protected override async UniTask PlayCloseAnimation()
        {
            await UniTask.WhenAll(
                base.PlayCloseAnimation(),
                TpRunner.Run(Config.ButtonsClose, _buttons)
            );
            
            _buttons.SetActive(false);
        }
    }
}