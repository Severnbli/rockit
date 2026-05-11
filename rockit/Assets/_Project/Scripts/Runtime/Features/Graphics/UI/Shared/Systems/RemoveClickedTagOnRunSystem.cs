using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Systems
{
    public sealed class RemoveClickedTagOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly UISharedAspect _usAspect;
        
        public void Run()
        {
            foreach (var e in _usAspect.ClickedTags)
            {
                _usAspect.ClickedTagPool.Del(e);
            }
        }
    }
}