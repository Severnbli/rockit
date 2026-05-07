using _Project.Scripts.Modules.Zenject;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs
{
    public class MusicConfig : ScriptableObjectAutoInstaller<MusicConfig>
    {
        [SerializeField] private TweenPipeline _transition;
        [SerializeField] private AudioClip _menu;
        [SerializeField] private AudioClip _game;

        public TweenPipeline Transition => _transition;
        public AudioClip Menu => _menu;
        public AudioClip Game => _game;
    }
}