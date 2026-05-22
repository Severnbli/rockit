using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Configs;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types
{
    public class CoinIconFactory : BasePrefabFactory<CoinIcon, CoinsIconFactoryCreateSettings>
    {
        protected readonly UIPrefabsStorageConfig UpsConfig;
        
        public CoinIconFactory(ProtoWorld world, UIPrefabsStorageConfig upsConfig) : base(world)
        {
            UpsConfig = upsConfig;
        }

        protected override GameObject GetPrefab() => UpsConfig.CoinIcon;
    }

    public struct CoinsIconFactoryCreateSettings
    {
        
    }
}