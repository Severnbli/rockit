using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Shared.Extensions.Infrastructure;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Tools.Player
{
    public class MusicPlayer : IMusicPlayer
    {
        protected IAudioEmitter PrimaryEmitter;
        protected IAudioEmitter SecondaryEmitter;
        protected Tween LastTransition;

        protected readonly MusicAudioSourcePool MasPool;
        protected readonly MusicConfig MConfig;
        protected readonly ITweenPipelineSequenceCreator TpsCreator;
        protected readonly CancellationToken Ct;

        public MusicPlayer(IObjectDomain objDomain, MusicConfig mConfig, ITweenPipelineSequenceCreator tpsCreator,
            CancellationToken ct)
        {
            objDomain.Get(out MasPool);
            MConfig = mConfig;
            TpsCreator = tpsCreator;
            Ct = ct;

            PrimaryEmitter = new AudioEmitter(MasPool.Spawn(), TpsCreator);
            SecondaryEmitter = new AudioEmitter(MasPool.Spawn(), TpsCreator);
        }
        
        public void Play(AudioClip clip, bool looped)
        {
            LastTransition?.Kill();
            
            var transition = MakeTransition(clip, looped);
            (PrimaryEmitter, SecondaryEmitter) = (SecondaryEmitter, PrimaryEmitter);
            LastTransition = transition;
        }

        public void Stop()
        {
            LastTransition?.Kill();
            PrimaryEmitter.Stop();
            SecondaryEmitter.Stop();
        }

        private Sequence MakeTransition(AudioClip clip, bool looped)
        {
            var fromEmitter = PrimaryEmitter;
            var toEmitter = SecondaryEmitter;
            
            var transition = fromEmitter
                .Animate(MConfig.TransitionFrom)
                .OnComplete(fromEmitter.Stop);

            if (clip != null)
            {
                transition.Join(toEmitter
                    .Animate(MConfig.TransitionTo)
                    .OnStart(() => toEmitter.Play(clip, looped)));
            }
            else
            {
                transition.Join(toEmitter
                    .Animate(MConfig.TransitionFrom)
                    .OnStart(fromEmitter.Stop));
            }
            
            transition.LinkToCancellationToken(Ct);
            return transition;
        }
    }
}