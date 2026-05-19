using _Project.Scripts.Runtime.Core.Bootstrap.Domain;
using _Project.Scripts.Runtime.Features.World.Levels.Services;
using _Project.Scripts.Runtime.Features.World.Levels.Types;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.World.Levels
{
    public sealed class LevelsSceneModule : BaseModule<LevelsSceneModule>
    {
        public LevelsSceneModule(IDomain domain) : base(domain)
        {
        }

        protected override void RegisterBindings()
        {
            base.RegisterBindings();

            Container.Bind<LevelFactory>().AsSingle();
        }
        
        protected override void BindServices()
        {
            base.BindServices();
            
            BindService<LevelsService>();
        }
    }
}