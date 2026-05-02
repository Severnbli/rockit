using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline
{
    public class TweenPipelineRunner : ITweenPipelineRunner
    {
        public async UniTask Run(TweenPipeline tp, GameObject go)
        {
            await UniTask.CompletedTask;
        }
    }
}