using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Physics.Moving.Characters.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics.Moving
{
    public sealed class CharactersMovingModule : BaseModule<CharactersMovingModule>
    {
        public CharactersMovingModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<LoadPlayerCharacterMoveComponentOnInitializeRequestSystem>();
            BindSystem<SetPlayerWalkDecelerationOnInitializeRequestSystem>();
            BindSystem<TranslatePlayerInputWalkToWalkRequestSystem>();
            BindSystem<TranslatePlayerInputJumpToJumpRequestSystem>();
            BindSystem<TranslatePlayerInputDashToDashRequestSystem>();
            BindSystem<GroundCheckUpdateSystem>();
            BindSystem<CreateMoveSnapByGroundCheckResultSystem>();
            BindSystem<RemoveMoveSnapByGroundCheckResultSystem>();
            BindSystem<ApplyJumpDecelerationOnFixedRunSystem>();
            BindSystem<ApplyJumpOnJumpRequestSystem>();
            BindSystem<SendJumpRequestByJumpBufferingSystem>();
            BindSystem<JumpBufferingExpireSystem>();
            BindSystem<DashTimeoutExpireSystem>();
            BindSystem<DashAirQuantityResetOnGroundedSystem>();
            BindSystem<UpdateCharacterMoveDirectionOnWalkRequestSystem>();
            BindSystem<ApplyWalkDecelerationOnFixedRunSystem>();
            BindSystem<ApplyWalkOnWalkRequestSystem>();
            BindSystem<ApplyDashOnDashRequestSystem>();
            BindSystem<ApplyDashTimeoutOnDashTimeoutRequestSystem>();
            BindSystem<PreventCharacterSlidingUpOnSideCollisionEnterSystem>();
            BindSystem<PreventCharacterSideHookingSystem>();
            BindSystem<CalculateCharacterImpactedVelocitySystem>();
            BindSystem<ApplyCharacterImpactedVelocityToRigidbodySystem>();
        }
    }
}