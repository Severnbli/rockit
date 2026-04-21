using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Platforms
{
    public sealed class PlatformsSharedModule : BaseModule<PlatformsSharedModule>
    {
        public PlatformsSharedModule(IDomain domain) : base(domain)
        {
        }
    }
}