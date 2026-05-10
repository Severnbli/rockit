using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems
{
    public sealed class RemoveButtonTriggeredTagOnRunSystem : IProtoRunSystem
    {
        [DI] private readonly ButtonsAspect _bAspect;
        
        public void Run()
        {
            foreach (var e in _bAspect.TriggeredButtons)
            {
                _bAspect.ButtonTriggeredTagPool.Del(e);
            }
        }
    }
}