using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public interface ITweenPipelineCacheStorage
    {
        bool TryGetFromCache(TweenPipeline tp, GameObject go, out Sequence sequence);
        void AddToCache(TweenPipeline tp, GameObject go, Sequence sequence);
    }
}