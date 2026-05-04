using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    public interface ITweenPipelineCacheStorage
    {
        Sequence GetFromCache(TweenPipeline tp, GameObject go);
        void AddToCache(TweenPipeline tp, GameObject go);
    }
}