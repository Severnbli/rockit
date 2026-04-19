using System.Collections.Generic;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Services
{
    public sealed class SharedIndexService
    {
        public readonly Dictionary<GameObject, ProtoPackedEntityWithWorld> GameObjectIndex = new ();
    }
}