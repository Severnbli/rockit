using _Project.Scripts.Runtime.Core.Infrastructure.Objects.Lifecycle.Factories;
using _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Monos;
using _Project.Scripts.Runtime.Features.Graphics.UI.Icons.Types;
using _Project.Scripts.Runtime.Features.Graphics.UI.Shared.Configs;
using _Project.Scripts.Runtime.Features.World.Levels.Components;
using _Project.Scripts.Runtime.Features.World.Levels.Configs;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.UI.Buttons.Types
{
    public class LevelButtonViewFactory : BasePrefabFactory<LevelButtonView, LevelButtonViewCreateSettings>
    {
        private readonly UIPrefabsStorageConfig _upsConfig;
        private readonly LevelsConfig _lConfig;
        private readonly StarIconFactory _siFactory;

        public LevelButtonViewFactory(ProtoWorld world, UIPrefabsStorageConfig upsConfig,
            LevelsConfig lConfig, StarIconFactory siFactory) : base(world)
        {
            _upsConfig = upsConfig;
            _lConfig = lConfig;
            _siFactory = siFactory;
        }

        protected override GameObject GetPrefab() => _upsConfig.LevelButton;
        
        protected override void ConfigureEntityOnCreate(LevelButtonView instance, ProtoEntity entity,
            LevelButtonViewCreateSettings settings = default)
        {
            base.ConfigureEntityOnCreate(instance, entity, settings);

            ref var liComponent = ref Pool<LevelItemComponent>().GetOrAdd(entity);
            liComponent.LevelId = settings.LevelId;
        }

        protected override void PostCreate(LevelButtonView instance, LevelButtonViewCreateSettings settings = default)
        {
            base.PostCreate(instance, settings);

            instance.IdText.text = settings.LevelId.ToString();
            instance.StarsToUnlockText.text = settings.StarsToUnlock.ToString();
            
            for (var i = 0; i < settings.StarsQuantity; i++)
            {
                _siFactory.Create(instance.StarsContainer.transform).Open();
            }
            
            var remainStars = _lConfig.MaxStarsPerLevel - settings.StarsQuantity;

            for (var i = 0; i < remainStars; i++)
            {
                _siFactory.Create(instance.StarsContainer.transform).Close();
            }
            
            instance.SetStatus(settings.Opened);
        }
    }

    public struct LevelButtonViewCreateSettings
    {
        public int LevelId;
        public bool Opened;
        public int StarsQuantity;
        public int StarsToUnlock;
    }
}