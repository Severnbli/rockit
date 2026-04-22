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
            
            BindSystem<SetPlayerWalkDecelerationOnInitializeRequestSystem>();
            BindSystem<TranslatePlayerInputWalkToWalkRequestSystem>();
            BindSystem<TranslatePlayerInputJumpToJumpRequestSystem>();
            BindSystem<TranslatePlayerInputDashToDashRequestSystem>();
            BindSystem<GroundCheckUpdateSystem>();
            BindSystem<CreateMoveSnapByGroundCheckResultSystem>();
            BindSystem<RemoveMoveSnapByGroundCheckResultSystem>();
            BindSystem<ApplyJumpOnJumpRequestSystem>();
            BindSystem<SendJumpRequestByJumpBufferingSystem>();
            BindSystem<JumpBufferingExpireSystem>();
            BindSystem<DashTimeoutExpireSystem>();
            BindSystem<DashAirQuantityResetOnGroundedSystem>();
            BindSystem<UpdateMoveDirectionOnWalkRequestSystem>();
            BindSystem<ApplyWalkDecelerationOnFixedRunSystem>();
            BindSystem<ApplyWalkOnWalkRequestSystem>();
            BindSystem<UpdateWalkDecelerationOnWalkRequestSystem>();
            BindSystem<ApplyDashOnDashRequestSystem>();
            BindSystem<ApplyDashTimeoutOnDashTimeoutRequestSystem>();
            BindSystem<PreventCharactersSlidingUpOnSideCollisionEnterSystem>();
            BindSystem<PreventCharacterSideHookingSystem>();
        }
    }
}