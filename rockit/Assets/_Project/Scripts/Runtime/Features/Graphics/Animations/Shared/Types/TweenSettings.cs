using System;
using DG.Tweening;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types
{
    [Serializable]
    public class TweenSettings
    {
        public bool Relative = false;
        public float Duration = 0.5f;
        public bool SpeedBased = false;
        public float Delay = 0f;
        public Ease Easing = Ease.Unset;
        public int Loops = 0;
        public LoopType LoopType = LoopType.Restart;
    }
}