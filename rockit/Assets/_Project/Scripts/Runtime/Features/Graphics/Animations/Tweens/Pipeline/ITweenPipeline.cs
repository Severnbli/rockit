using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline
{
    public interface ITweenPipeline
    {
        UniTask PlayWith(GameObject go);
    }
}