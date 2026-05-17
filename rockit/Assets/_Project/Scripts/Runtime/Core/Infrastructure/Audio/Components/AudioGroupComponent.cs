using System;
using _Project.Scripts.Runtime.Core.Infrastructure.Audio.Types;
using Leopotam.EcsProto.Unity;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Audio.Components
{
    [Serializable, ProtoUnityAuthoring]
    public struct AudioGroupComponent
    {
        public AudioGroup Group;
    }
}