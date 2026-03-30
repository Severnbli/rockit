using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Core.Infrastructure.Storage;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure
{
    public class StorageModule : BaseModule<StorageModule>
    {
        public StorageModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.BindInterfacesAndSelfTo<TypeNameDataStorageKeyProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerPrefsDataProvider>().AsSingle();
        }
    }
}