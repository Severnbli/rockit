using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class RemoveDropdownChangeOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly UISharedAspect _usAspect;
        
        public void Run()
        {
            foreach (var e in _usAspect.DropdownChanges)
            {
                _usAspect.DropdownChangeComponentPool.Del(e);
            }
        }
    }
}