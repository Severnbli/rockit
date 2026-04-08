using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Input.Services;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features
{
    public sealed class InputModule : BaseModule<InputModule>
    {
        public InputModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<PlayerInputService>();
        }
    }
}