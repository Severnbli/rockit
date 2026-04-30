using System;
using DG.Tweening;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types
{
    [Serializable]
    public class TweenSettings
    {
        public bool FromExact = false;
        public bool Relative = false;
        public float Duration = 0.5f;
        public bool SpeedBased = false;
        public float Delay = 0f;
        public Ease Ease = Ease.Unset;
        public int Loops = 1;
        public LoopType LoopType = LoopType.Restart;
    }
}