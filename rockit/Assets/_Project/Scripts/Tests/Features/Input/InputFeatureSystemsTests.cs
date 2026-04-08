using NUnit.Framework;

namespace _Project.Scripts.Tests.Features.Input
{
    public class InputFeatureSystemsTests : BaseSystemsTests
    {

        private void AssertRequestsEmpty()
        {
            Assert.True(RequestsWorldAspect.InputAspect.EnablePlayerInputRequests.IsEmptySlow());
            Assert.True(RequestsWorldAspect.InputAspect.DisablePlayerInputRequests.IsEmptySlow());
            Assert.True(RequestsWorldAspect.InputAspect.EnablePlatformsInputRequests.IsEmptySlow());
            Assert.True(RequestsWorldAspect.InputAspect.DisablePlatformsInputRequests.IsEmptySlow());
        }
    }
}