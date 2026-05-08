using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tweens.Pipeline.Core
{
    public interface ITweenPipelineSequenceCreator
    {
        Sequence CreateSequence(TweenPipeline tp, GameObject go);
    }
}