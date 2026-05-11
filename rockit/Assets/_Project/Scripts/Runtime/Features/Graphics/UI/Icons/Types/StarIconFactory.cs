using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Configs;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types
{
    public class StarIconFactory : BasePrefabFactory<StarIcon, StarIconCreateSettings>
    {
        private readonly UIPrefabsStorageConfig _upsConfig;
        
        public StarIconFactory(ProtoWorld world, UIPrefabsStorageConfig upsConfig) : base(world)
        {
            _upsConfig = upsConfig;
        }

        protected override GameObject GetPrefab() => _upsConfig.StarIcon;

        protected override void PostCreate(StarIcon instance, StarIconCreateSettings settings = default)
        {
            base.PostCreate(instance, settings);
            
            instance.SetStatus(settings.Opened);
        }
    }

    public struct StarIconCreateSettings
    {
        public bool Opened;
    }
}