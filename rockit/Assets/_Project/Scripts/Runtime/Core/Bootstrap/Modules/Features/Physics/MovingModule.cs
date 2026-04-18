using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Physics.Moving.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics
{
    public sealed class MovingModule : BaseModule<MovingModule>
    {
        public MovingModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<TranslatePlayerInputWalkToWalkRequestSystem>();
            BindSystem<TranslatePlayerInputJumpToJumpRequestSystem>();
            BindSystem<TranslatePlayerInputDashToDashRequestSystem>();
            BindSystem<GroundCheckUpdateSystem>();
            BindSystem<ApplyGroundVelocityToGroundedObjectSystem>();
            BindSystem<ApplyJumpOnJumpRequestSystem>();
            BindSystem<SendJumpRequestByJumpBufferingSystem>();
            BindSystem<JumpBufferingExpireSystem>();
            BindSystem<DashTimeoutExpireSystem>();
            BindSystem<DashAirQuantityResetOnGroundedSystem>();
            BindSystem<UpdateMoveDirectionOnWalkRequestSystem>();
            BindSystem<ApplyWalkOnWalkRequestSystem>();
            BindSystem<UpdateWalkDecelerationOnWalkRequestSystem>();
            BindSystem<ApplyDashOnDashRequestSystem>();
            BindSystem<ApplyDashTimeoutOnDashTimeoutRequestSystem>();
        }
    }
}