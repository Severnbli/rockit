using _Project.Scripts.Runtime.Features.Graphics.UI.Shared;
using _Project.Scripts.Runtime.Shared.Extensions.Shared;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Systems
{
    public sealed class SetActiveUIElementStatusByButtonInteractableStatusSystem : IProtoRunSystem
    {
        [DI] private readonly ButtonsAspect _bAspect;
        [DI] private readonly UISharedAspect _usAspect;
        
        public void Run()
        {
            foreach (var e in _bAspect.Buttons)
            {
                ref var bComponent = ref _bAspect.ButtonComponentPool.Get(e);
                _usAspect.ActiveUIElementTagPool.AddOrDelOnCondition(e, bComponent.Button.interactable);
            }
        }
    }
}