using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    public class TweenPipelineCacheStorage : ITweenPipelineCacheStorage
    {
        protected readonly Dictionary<(TweenPipeline, GameObject), Sequence> Cache = new ();
        
        public bool TryGetFromCache(TweenPipeline tp, GameObject go, out Sequence sequence)
        {
            sequence = null;
            return false;
        }

        public void AddToCache(TweenPipeline tp, GameObject go)
        {
            
        }
    }
}