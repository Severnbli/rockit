using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Animations.Tools.Pipeline.Core
{
    public class TweenPipelineSequenceCreator : ITweenPipelineSequenceCreator
    {
        protected readonly DictionaryPool<Type, Component> GoCachePool;

        public TweenPipelineSequenceCreator(IObjectDomain objDomain)
        {
            objDomain.Get(out GoCachePool);
        }

        public Sequence CreateSequence(TweenPipeline tp, GameObject go)
        {
            var sequence = DOTween.Sequence();
            var goCache = GoCachePool.Spawn();

            foreach (var step in tp.Steps)
            {
                step.TryDoStep(sequence, go, goCache);
            }

            sequence.SetLoops(tp.Loops, tp.LoopType);
            
            GoCachePool.Despawn(goCache);
            return sequence;
        }
    }
}