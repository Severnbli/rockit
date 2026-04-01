using System.Threading;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Escort;
using _Project.Scripts.Runtime.Core.Infrastructure.Scenes.Switcher.Loader;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using UnityEngine;

namespace _Project.Scripts.Tests.NonSystems.Scenes.Switcher
{
    public class SceneSwitcherTests
    {
        private void OneTimeSetUp()
        {
            var switcherService = new SceneSwitcherService();
            var timeService = new TimeService();
            var loaderConfig = ScriptableObject.CreateInstance<SceneLoaderConfig>();
            
            var cts = new CancellationTokenSource();
            
            var loadingEscort = new SceneLoadingEscort(cts.Token, switcherService);
            var loader = new SceneLoader(switcherService, loadingEscort, timeService, loaderConfig, cts.Token);
            var sceneSwitcher = new SceneSwitcher(switcherService, loader);
        }
    }
}