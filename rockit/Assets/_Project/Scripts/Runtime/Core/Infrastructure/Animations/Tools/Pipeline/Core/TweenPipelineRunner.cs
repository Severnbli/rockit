using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public class TweenPipelineRunner : ITweenPipelineRunner
    {
        protected readonly ITweenPipelineCacheStorage Cache;
        protected readonly ITweenPipelineSequenceCreator Creator;
        protected readonly CancellationToken Ct;
        
        protected readonly Dictionary<GameObject, ITweenPipelineRunObserver> Observers = new ();
        protected readonly TweenPipelineRunObserverPool<TweenPipelineCachedRunObserver> CachedObserversPool = new ();
        protected readonly TweenPipelineRunObserverPool<TweenPipelineNonCachedRunObserver> NonCachedObserversPool = new ();

        public TweenPipelineRunner(CancellationToken ct, ITweenPipelineCacheStorage cache, ITweenPipelineSequenceCreator creator)
        {
            Ct = ct;
            Cache = cache;
            Creator = creator;
        }

        public async UniTask Run(TweenPipeline tp, GameObject go, bool caching = false)
        {
            if (Observers.TryGetValue(go, out var observer))
            {
                observer.CancelRun();
                Observers.Remove(go);
            }
            
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

            var observer = CachedObserversPool.Spawn();
            await AwaitWithObserver(sequence.AwaitForComplete(cancellationToken: Ct), sequence, go, observer);
            CachedObserversPool.Despawn(observer);
        }

        private async UniTask RunNonCached(TweenPipeline tp, GameObject go)
        {
            var sequence = Creator.CreateSequence(tp, go);
            
            var observer = NonCachedObserversPool.Spawn();
            await AwaitWithObserver(sequence.ToUniTask(cancellationToken: Ct), sequence, go, observer);
            NonCachedObserversPool.Despawn(observer);
        }

        private async UniTask AwaitWithObserver(UniTask task, Sequence sequence, GameObject go, 
            ITweenPipelineRunObserver observer)
        {
            observer.Initialize(sequence);
            Observers[go] = observer;
            
            await task;
            
            if (observer.Canceled) return;
            Observers.Remove(go);
        }
        
        public void CacheRun(TweenPipeline tp, GameObject go)
        {
            var sequence = Creator.CreateSequence(tp, go);
            Cache.AddToCache(tp, go, sequence);
            sequence.Pause();
        }
    }
}