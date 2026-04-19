using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Graphics.Animations.Characters.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Animations
{
    public sealed class CharactersAnimationsModule : BaseModule<CharactersAnimationsModule>
    {
        public CharactersAnimationsModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<SendDashTriggerOnDashRequestSystem>();
            BindSystem<UpdateDashedBoolOnRunSystem>();
            BindSystem<UpdateFallBoolByVelocityOnFixedRunSystem>();
        }
    }
}