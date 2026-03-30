using _Project.Scripts.Runtime.Core.Bootstrap.Domain;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public class StorageModule : BaseModule<StorageModule>
    {
        public StorageModule(IDomain domain) : base(domain)
        {
        }
        
        
    }
}