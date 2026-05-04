using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    public interface ITweenPipelineRunner
    {
        UniTask Run(TweenPipeline tp, GameObject go, bool caching = false);
        void CacheRun(TweenPipeline tp, GameObject go);
    }
}