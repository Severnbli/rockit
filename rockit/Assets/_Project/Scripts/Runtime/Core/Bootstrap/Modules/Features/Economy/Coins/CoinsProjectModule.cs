using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.Economy.Coins.Systems;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Economy.Coins
{
    public sealed class CoinsProjectModule : BaseModule<CoinsProjectModule>
    {
        public CoinsProjectModule(IDomain domain) : base(domain)
        {
        }

        protected override void BindSystems()
        {
            base.BindSystems();
            
            BindSystem<WasteCoinsOnWasteCoinsRequestSystem>();
        }
    }
}