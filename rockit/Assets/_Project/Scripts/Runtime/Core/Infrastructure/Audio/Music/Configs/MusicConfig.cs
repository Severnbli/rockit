using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Sfx.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Shared.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Music.Configs
{
    public class MusicConfig : AudioConfig<SfxConfig>
    {
        [SerializeField] private TweenPipeline _transitionFrom;
        [SerializeField] private TweenPipeline _transitionTo;
        [SerializeField] private AudioClip _menu;
        [SerializeField] private AudioClip _game;
        [SerializeField] private AudioClip _loading;

        public TweenPipeline TransitionFrom => _transitionFrom;
        public TweenPipeline TransitionTo => _transitionTo;
        public AudioClip Menu => _menu;
        public AudioClip Game => _game;
        public AudioClip Loading => _loading;
    }
}