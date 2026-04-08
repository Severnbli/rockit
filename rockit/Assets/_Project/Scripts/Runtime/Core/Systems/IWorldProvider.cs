using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Core.Systems
{
    public interface IWorldProvider
    {
        ProtoWorld GetWorld();
    }
}