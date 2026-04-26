using System;
using _Project.Scripts.Runtime.Shared.Callback.Events;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Shared.Events
{
    public sealed class CustomEventsModule : IProtoModule
    {
        private readonly string _worldName;
        private readonly int _clearPointWeight;
        
        public CustomEventsModule (string worldName = default, int clearPointWeight = default) {
            _worldName = worldName;
            _clearPointWeight = clearPointWeight;
        }
        
        public void Init(IProtoSystems systems)
        {
            systems
                .DelHere<UnityPhysics2DCollisionStayEvent>(_worldName, _clearPointWeight);
        }

        public IProtoAspect[] Aspects()
        {
            return null;
        }

        public Type[] Dependencies() => new Type[] { typeof(UnityModule) };
    }
}