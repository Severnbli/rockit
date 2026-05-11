using _Project.Scripts.Runtime.Core.Infrastructure.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class OpenOpenableOnClickedItemSystem : IProtoRunSystem
    {
        [DI] private readonly UISharedAspect _usAspect;
        [DI] private readonly SharedAspect _sAspect;
        
        public void Run()
        {
            foreach (var e in _usAspect.ClickedOpenableItems)
            {
                ref var ocComponent = ref _sAspect.OpenableClosableComponentPool.Get(e);
                ocComponent.OpenableClosable.Open();
            }
        }
    }
}