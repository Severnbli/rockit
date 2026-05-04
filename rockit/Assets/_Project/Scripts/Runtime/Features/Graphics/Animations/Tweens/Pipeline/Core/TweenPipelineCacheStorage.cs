using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    public class TweenPipelineCacheStorage : ITweenPipelineCacheStorage
    {
        protected readonly Dictionary<(TweenPipeline, GameObject), Sequence> Cache = new ();
        
        public Sequence GetFromCache(TweenPipeline tp, GameObject go)
        {
            return null;
        }

        public void AddToCache(TweenPipeline tp, GameObject go)
        {
            
        }
    }
}