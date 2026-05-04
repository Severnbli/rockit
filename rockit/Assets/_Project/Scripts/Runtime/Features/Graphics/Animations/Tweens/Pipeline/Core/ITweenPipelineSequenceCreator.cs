using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    public interface ITweenPipelineSequenceCreator
    {
        Sequence CreateSequence(TweenPipeline tp, GameObject go);
    }
}