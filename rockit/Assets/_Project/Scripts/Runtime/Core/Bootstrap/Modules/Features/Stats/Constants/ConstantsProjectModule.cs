using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Stats.Constants.Services;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats.Constants
{
    public sealed class ConstantsProjectModule : BaseModule<ConstantsProjectModule>
    {
        public ConstantsProjectModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<ConstantsDisplaysService>();
        }
    }
}