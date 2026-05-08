using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tweens.Pipeline.Core
{
    public class TweenPipelineCacheStorage : ITweenPipelineCacheStorage
    {
        protected readonly Dictionary<(TweenPipeline, GameObject), Sequence> Cache = new ();
        
        public bool TryGetFromCache(TweenPipeline tp, GameObject go, out Sequence sequence)
        {
            return Cache.TryGetValue((tp, go), out sequence);
        }

        public void AddToCache(TweenPipeline tp, GameObject go, Sequence sequence)
        {
            Cache[(tp, go)] = sequence;
            sequence.SetAutoKill(false);
        }
    }
}