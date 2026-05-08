using _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tweens.Pipeline.Core;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Configs;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Types;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
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
        
        public MusicPlayer(IObjectDomain objDomain, MusicConfig mConfig, ITweenPipelineSequenceCreator tpsCreator)
        {
            objDomain.Get(out MasPool);
            MConfig = mConfig;
            TpsCreator = tpsCreator;

            PrimaryEmitter = new AudioEmitter(MasPool.Spawn(), TpsCreator);
            SecondaryEmitter = new AudioEmitter(MasPool.Spawn(), TpsCreator);
        }
        
        public void Play(AudioClip clip, bool looped)
        {
            LastTransition?.Kill();
            
            var transition = PrimaryEmitter
                .Animate(MConfig.TransitionFrom)
                .OnComplete(() => PrimaryEmitter.Stop());
            
            transition.Join(SecondaryEmitter
                    .Animate(MConfig.TransitionTo)
                    .OnStart(() => SecondaryEmitter.Play(clip, looped)));
            
            (PrimaryEmitter, SecondaryEmitter) = (SecondaryEmitter, PrimaryEmitter);
            
            LastTransition = transition;
        }

        public void Stop()
        {
            LastTransition?.Kill();
            PrimaryEmitter.Stop();
        }
    }
}