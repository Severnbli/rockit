using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public sealed class AudioModule : BaseModule<AudioModule>
    {
        public AudioModule(IDomain domain) : base(domain)
        {
        }
    }
}