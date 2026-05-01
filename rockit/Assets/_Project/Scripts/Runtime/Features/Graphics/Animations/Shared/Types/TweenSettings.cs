using System;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Shared.Types
{
    [Serializable]
    public class TweenSettings<T>
    {
        [SerializeField] private T _to;
        [SerializeField] private T _from;
        [SerializeField] private bool _fromExact = false;
        [SerializeField] private bool _relative = false;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private bool _speedBased = false;
        [SerializeField] private float _delay = 0f;
        [SerializeField] private Ease _ease = Ease.Unset;
        [SerializeField] private int _loops = 1;
        [SerializeField] private LoopType _loopType = LoopType.Restart;
        
        public T To => _to;
        public T From => _from;
        public bool FromExact => _fromExact;
        public bool Relative => _relative;
        public float Duration => _duration;
        public bool SpeedBased => _speedBased;
        public float Delay => _delay;
        public Ease Ease => _ease;
        public int Loops => _loops;
        public LoopType LoopType => _loopType;
    }
}