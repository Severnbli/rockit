using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player
{
    public class AudioEmitter : IAudioEmitter
    {
        protected readonly AudioSource Source;
        protected readonly ITweenPipelineSequenceCreator _tpsCreator;

        public AudioEmitter(AudioSource source, ITweenPipelineSequenceCreator tpsCreator)
        {
            Source = source;
            _tpsCreator = tpsCreator;
        }

        public void Play(AudioClip clip, bool looped = true)
        {
            Source.clip = clip;
            Source.loop = looped;
            Source.Play();
        }

        public void Stop()
        {
            Source.Stop();
        }

        public Sequence Animate(TweenPipeline tp)
        {
            return _tpsCreator.CreateSequence(tp, Source.gameObject);
        }
    }
}