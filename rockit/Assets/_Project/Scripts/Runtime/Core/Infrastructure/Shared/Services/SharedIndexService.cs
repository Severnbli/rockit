using _Project.Scripts.Runtime.Shared.Tools;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services
{
    public sealed class SharedIndexService
    {
        public BiDictionary<GameObject, ProtoPackedEntityWithWorld> GameObjectIndex = new ();
    }
}