using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public interface ITweenPipelineStep
    {
        bool TryDoStep(Sequence sequence, GameObject go, Dictionary<Type, Component> goCache);
    }
}