using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Physics.Moving.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Moving
{
    public sealed class MovingModule : BaseModule<MovingModule>
    {
        public MovingModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<GroundCheckUpdateSystem>();
            BindSystem<ApplyGroundVelocityToGroundedObjectSystem>();
        }
    }
}