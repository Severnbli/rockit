using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Configs;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types
{
    public class AnimatableStarIconFactory : BasePrefabFactory<AnimatableStarIcon, AnimatableStarIconFactoryCreateSettings>
    {
        protected readonly UIPrefabsStorageConfig UpsConfig;
        
        public AnimatableStarIconFactory(ProtoWorld world, UIPrefabsStorageConfig upsConfig) : base(world)
        {
            UpsConfig = upsConfig;
        }

        protected override GameObject GetPrefab() => UpsConfig.AnimatableStarIcon;
    }

    public struct AnimatableStarIconFactoryCreateSettings
    {
        
    }
}