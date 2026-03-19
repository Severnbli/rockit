using _Project.Scripts.Runtime.Core.Systems;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems
{
    public class DebugSystem : IProtoRunSystem, IProtoFixedRunSystem
    {
        [DI] private RequestsAspect _requestsAspect;
        
        public void Run()
        {
            DisplayRunActivated();
            CreateRunRequest();
        }

        public void FixedRun()
        {
            DisplayFixedRunActivated();
            CreateFixedRunRequest();
        }
        
        private ProtoEntity CreateRequest()
        {
            ref var request = ref _requestsAspect.RequestComponentPool.NewEntity(out var entity);
            request.Entity = _requestsAspect.World().PackEntity(entity);
            return entity;
        }

        private void CreateRunRequest()
        {
            var entity = CreateRequest();
            _requestsAspect.RunRequestTagPool.Add(entity);
        }
        
        private void CreateFixedRunRequest()
        {
            var entity = CreateRequest();
            _requestsAspect.FixedRunRequestTagPool.Add(entity);
        }

        private void DisplayRunActivated()
        {
            Debug.Log(_requestsAspect.RunActivated.LenSlow().Equals(1) ? "GOOD" : "NOT GOOD 1");
        }

        private void DisplayFixedRunActivated()
        {
            Debug.Log(_requestsAspect.FixedRunActivated.LenSlow().Equals(1) ? "GOOD" : "NOT GOOD 2");
        }
    }
}