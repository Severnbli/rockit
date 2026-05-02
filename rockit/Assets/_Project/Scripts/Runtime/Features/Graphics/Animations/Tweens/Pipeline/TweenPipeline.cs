using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline
{
    public class TweenPipeline : ITweenPipeline
    {
        public async UniTask PlayWith(GameObject go)
        {
            await UniTask.CompletedTask;
        }
    }
}