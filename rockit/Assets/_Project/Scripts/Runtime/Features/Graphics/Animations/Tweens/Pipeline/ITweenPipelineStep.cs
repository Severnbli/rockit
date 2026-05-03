using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline
{
    public interface ITweenPipelineStep
    {
        bool TryDoStep(Sequence sequence, GameObject go, Dictionary<Type, Component> goCache);
    }
}