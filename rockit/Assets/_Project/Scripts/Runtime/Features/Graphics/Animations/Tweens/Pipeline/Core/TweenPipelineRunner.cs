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
            await UniTask.CompletedTask;
        }
    }
}