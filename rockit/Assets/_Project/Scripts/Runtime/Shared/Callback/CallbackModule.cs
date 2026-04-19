using System;
using _Project.Scripts.Runtime.Shared.Callback.Events;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Shared.Callback
{
    public sealed class CallbackModule : IProtoModule
    {
        private readonly string _worldName;
        private readonly int _clearPointWeight;
        
        public CallbackModule (string worldName = default, int clearPointWeight = default) {
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
            return _worldName != null 
                ? null
                : new IProtoAspect[] { new CallbackAspect() };
        }

        public Type[] Dependencies() => new Type[] { typeof(UnityModule) };
    }
}