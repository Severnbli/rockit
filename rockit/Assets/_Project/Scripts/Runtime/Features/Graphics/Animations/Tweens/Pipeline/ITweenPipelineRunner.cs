using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline
{
    public interface ITweenPipelineRunner
    {
        UniTask PlayWith(GameObject go);
    }
}