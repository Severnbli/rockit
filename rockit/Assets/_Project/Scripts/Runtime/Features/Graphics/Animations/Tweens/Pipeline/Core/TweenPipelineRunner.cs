using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    public class TweenPipelineRunner : ITweenPipelineRunner
    {
        protected readonly ITweenPipelineCacheStorage Cache;
        protected readonly ITweenPipelineSequenceCreator Creator;
        protected readonly CancellationToken Ct;

        public TweenPipelineRunner(CancellationToken ct, ITweenPipelineCacheStorage cache, ITweenPipelineSequenceCreator creator)
        {
            Ct = ct;
            Cache = cache;
            Creator = creator;
        }

        public async UniTask Run(TweenPipeline tp, GameObject go, bool caching = false)
        {
            if (caching)
            {
                await RunCached(tp, go);
                return;
            }
            
            await RunNonCached(tp, go);
        }

        private async UniTask RunCached(TweenPipeline tp, GameObject go)
        {
            if (!Cache.TryGetFromCache(tp, go, out var sequence))
            {
                sequence = Creator.CreateSequence(tp, go);
                Cache.AddToCache(tp, go, sequence);
            }
            
            sequence.Restart();
            await sequence.AwaitForComplete(cancellationToken: Ct);
        }

        private async UniTask RunNonCached(TweenPipeline tp, GameObject go)
        {
            var sequence = Creator.CreateSequence(tp, go);
            await sequence.ToUniTask(cancellationToken: Ct);
        }
        
        public void CacheRun(TweenPipeline tp, GameObject go)
        {
            var sequence = Creator.CreateSequence(tp, go);
            Cache.AddToCache(tp, go, sequence);
            sequence.Pause();
        }
    }
}