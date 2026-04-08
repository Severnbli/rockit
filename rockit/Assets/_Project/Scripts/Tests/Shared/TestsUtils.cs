using UnityEngine;

namespace _Project.Scripts.Tests.Shared
{
    public static class TestsUtils
    {
        public static TestsConfigs GetTestsConfigs()
        {
            return Resources.Load<TestsConfigs>(TestsContracts.TestsConfigsResourcesPath);
        }
    }
}