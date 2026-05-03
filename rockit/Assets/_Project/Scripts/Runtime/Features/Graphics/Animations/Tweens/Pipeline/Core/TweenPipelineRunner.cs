using _Project.Scripts.Runtime.Shared.Tools;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    public class TweenPipelineRunner : ITweenPipelineRunner
    {
        protected readonly BiValueDictionary<GameObject, TweenPipeline, Sequence> _cache = new ();
        
        public async UniTask Run(TweenPipeline tp, GameObject go, bool caching = false)
        {
            await UniTask.CompletedTask;
        }
    }
}