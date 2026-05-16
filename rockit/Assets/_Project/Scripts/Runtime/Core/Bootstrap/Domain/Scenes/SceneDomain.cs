using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Economy.Coins;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Animations;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.Sprites;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Text;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Graphics.UI.Windows;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Physics.Moving;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Features.Stats.Constants;
using _Project.Scripts.Runtime.Core.Bootstrap.Modules.Infrastructure;
using _Project.Scripts.Runtime.Core.Bootstrap.States.Scenes;
using _Project.Scripts.Runtime.Features.Graphics.Cameras.Monos;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Bootstrap.Domain.Scenes
{
    public abstract class SceneDomain : BaseDomain
    {
        [SerializeField] private MenusCamera _mCamera;
        [SerializeField] private PlayerCamera _pCamera;
        [SerializeField] private CameraBrain _cBrain;
        
        protected override void RegisterBindings()
        {
            base.RegisterBindings();
            
            Container.BindInstance(_mCamera).AsSingle();
            Container.BindInstance(_pCamera).AsSingle();
            Container.BindInstance(_cBrain).AsSingle();
            Container.Bind<SceneStatesBootstrapper>().ToSelf().AsSingle().NonLazy();
        }

        protected override void RegisterModules()
        {
            base.RegisterModules();

            TryRegisterModule<SharedModule>();
            TryRegisterModule<PhysicsSharedModule>();
            TryRegisterModule<CharactersMovingModule>();
            TryRegisterModule<MovingSharedModule>();
            TryRegisterModule<CharactersAnimationsModule>();
            TryRegisterModule<ConstantsAnimationsModule>();
            TryRegisterModule<SpritesSharedModule>();
            TryRegisterModule<SpritesGlowModule>();
            TryRegisterModule<TextSharedModule>();
            TryRegisterModule<UISharedModule>();
            TryRegisterModule<ButtonsModule>();
            TryRegisterModule<IconsModule>();
            TryRegisterModule<CoinsSceneModule>();
            TryRegisterModule<ConstantsSceneModule>();
            TryRegisterModule<WindowsSharedModule>();
            TryRegisterModule<CamerasModule>();
        }
    }
}