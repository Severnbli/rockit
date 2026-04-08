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

        private void AssertRequestsOnlyOne()
        {
            Assert.AreEqual(RequestsWorldAspect.InputAspect.EnablePlayerInputRequests.LenSlow(), 1);
            Assert.AreEqual(RequestsWorldAspect.InputAspect.DisablePlayerInputRequests.LenSlow(), 1);
            Assert.AreEqual(RequestsWorldAspect.InputAspect.EnablePlatformsInputRequests.LenSlow(), 1);
            Assert.AreEqual(RequestsWorldAspect.InputAspect.DisablePlatformsInputRequests.LenSlow(), 1);
        }
    }
}