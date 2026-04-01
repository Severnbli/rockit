using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using NUnit.Framework;
using UnityEngine;

namespace _Project.Scripts.Tests.NonSystems.Scenes.Switcher
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
        
        [OneTimeSetUp]
        private void OneTimeSetUp()
        {
            _switcherService = new SceneSwitcherService();
            _timeService = new TimeService();
            _loaderConfig = ScriptableObject.CreateInstance<SceneLoaderConfig>();
            
            _cts = new CancellationTokenSource();
            
            _loadingEscort = new SceneLoadingEscort(_cts.Token, _switcherService);
            _loader = new SceneLoader(_switcherService, _loadingEscort, _timeService, _loaderConfig, _cts.Token);
            _switcher = new SceneSwitcher(_switcherService, _loader);
        }
    }
}