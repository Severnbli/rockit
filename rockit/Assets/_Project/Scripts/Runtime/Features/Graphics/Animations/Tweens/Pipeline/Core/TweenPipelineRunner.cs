using System;
using System.Collections.Generic;
using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Pools.Collections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Tweens.Pipeline.Core
{
    public class TweenPipelineRunner : ITweenPipelineRunner
    {
        protected readonly Dictionary<(GameObject, TweenPipeline), Sequence> _cache = new ();
        protected readonly DictionaryPool<Type, Component> _goCachePool;
        protected readonly CancellationToken Ct;

        public TweenPipelineRunner(IObjectDomain objDomain, CancellationToken ct)
        {
            Ct = ct;
            objDomain.Get(out _goCachePool);
        }

        public async UniTask Run(TweenPipeline tp, GameObject go, bool caching = false)
        {
            if (caching)
            {
                await RunCached(tp, go);
                return;
            }
            
            await RunNonCached(tp, go);
        }

        private async UniTask RunCached(TweenPipeline tp, GameObject go)
        {
            if (!_cache.TryGetValue((go, tp), out var sequence))
            {
                sequence = GetSequence(tp, go);
                _cache[(go, tp)] = sequence;
                sequence.SetAutoKill(false);
            }
            
            sequence.Restart();
            await sequence.AwaitForComplete(cancellationToken: Ct);
        }

        private async UniTask RunNonCached(TweenPipeline tp, GameObject go)
        {
            var sequence = GetSequence(tp, go);
            await sequence.ToUniTask(cancellationToken: Ct);
        }

        private Sequence GetSequence(TweenPipeline tp, GameObject go)
        {
            var sequence = DOTween.Sequence();
            var goCache = _goCachePool.Spawn();

            foreach (var step in tp.Steps)
            {
                step.TryDoStep(sequence, go, goCache);
            }
            
            _goCachePool.Despawn(goCache);
            return sequence;
        }
    }
}