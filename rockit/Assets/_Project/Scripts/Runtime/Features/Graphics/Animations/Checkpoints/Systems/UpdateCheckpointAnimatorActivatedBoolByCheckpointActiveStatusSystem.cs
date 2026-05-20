using _Project.Scripts.Runtime.Features.Graphics.Animations.Checkpoints.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Shared;
using _Project.Scripts.Runtime.Features.World.Checkpoints;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

namespace _Project.Scripts.Runtime.Features.Graphics.Animations.Checkpoints.Systems
{
    public sealed class UpdateCheckpointAnimatorActivatedBoolByCheckpointActiveStatusSystem : IProtoRunSystem
    {
        [DI] private readonly CheckpointsAnimationsAspect _caAspect;
        [DI] private readonly AnimationsSharedAspect _asAspect;
        [DI] private readonly CheckpointsAspect _cAspect;
        private readonly CheckpointsAnimationsConfig _caConfig;
        
        public void Run()
        {
            foreach (var e in _caAspect.CheckpointAnimators)
            {
                ref var aComponent = ref _asAspect.AnimatorComponentPool.Get(e);
                var active = _cAspect.ActiveCheckpoints.Has(e);
                
                aComponent.Animator.SetBool(_caConfig.ActivatedBool, active);
            }
        }
    }
}