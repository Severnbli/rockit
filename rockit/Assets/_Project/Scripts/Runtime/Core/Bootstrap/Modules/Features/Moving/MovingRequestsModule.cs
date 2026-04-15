using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Moving.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Moving
{
    public sealed class MovingRequestsModule : BaseModule<MovingRequestsModule>
    {
        public MovingRequestsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<TranslatePlayerInputWalkToWalkRequestSystem>();
            BindSystem<TranslatePlayerInputJumpToJumpRequestSystem>();
            BindSystem<TranslatePlayerInputDashToDashRequestSystem>();
        }
    }
}