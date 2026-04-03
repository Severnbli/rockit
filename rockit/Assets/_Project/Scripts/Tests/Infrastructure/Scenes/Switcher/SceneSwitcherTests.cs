using System.Threading;
using System.Threading.Tasks;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using NUnit.Framework;
using UnityEngine;

namespace _Project.Scripts.Tests.Infrastructure.Scenes.Switcher
{
    public class SceneSwitcherTests
    {
        private SceneSwitcherService _switcherService;
        private TimeService _timeService;
        private SceneLoaderConfig _loaderConfig;
        private CancellationTokenSource _cts;
        private ISceneLoadingEscort _loadingEscort;
        private ISceneLoader _loader;
        private ISceneSwitcher _switcher;

        [SetUp]
        public void SetUp()
        {
            _switcherService = new SceneSwitcherService();
            _timeService = new TimeService();
            _loaderConfig = ScriptableObject.CreateInstance<SceneLoaderConfig>();
            _cts = new CancellationTokenSource();
            _loadingEscort = new SceneLoadingEscort(_cts.Token, _switcherService);
            _loader = new SceneLoader(_switcherService, _loadingEscort, _timeService, _loaderConfig, _cts.Token);
            _switcher = new SceneSwitcher(_switcherService, _loader);
        }

        [Test]
        public async Task TestLoadingSimulation()
        {
            _loaderConfig.SetSimulateLoading(false);
            
            var startTime = Time.time;
            await _switcher.SwitchScene(ScenesContracts.MenuScene);
            var endTime = Time.time;
            
            var idealTime = endTime - startTime;
            
            var timeout = idealTime * 2f;
            _loaderConfig.SetSimulateLoading(true);
            _loaderConfig.SetSimulateLoadingDuration(timeout);
            
            startTime = Time.time;
            await _switcher.SwitchScene(ScenesContracts.MenuScene);
            endTime = Time.time;
            
            var simulatedTime = endTime - startTime;

            Assert.Greater(simulatedTime, timeout);
        }

        [Test]
        public async Task TestTrySwitchToLoadedScene()
        {
            Assert.False(_switcher.TrySwitchToLoadedScene());
            
            await _switcher.SwitchScene(ScenesContracts.MenuScene, false);
            Assert.True(_switcher.TrySwitchToLoadedScene());
            
            Assert.False(_switcher.TrySwitchToLoadedScene());
        }
        
        [Test]
        public async Task TestUnableToLoadAnotherSceneOnOtherLoaded()
        {
            var startTime = Time.time;
            await _switcher.SwitchScene(ScenesContracts.MenuScene, false);
            var endTime = Time.time;
            
            var idealTime = endTime - startTime;
            
            startTime = Time.time;
            await _switcher.SwitchScene(ScenesContracts.MenuScene, false);
            endTime = Time.time;
            
            var estimatedTime = endTime - startTime;
            
            Assert.Less(estimatedTime, idealTime / 2f);
        }
    }
}