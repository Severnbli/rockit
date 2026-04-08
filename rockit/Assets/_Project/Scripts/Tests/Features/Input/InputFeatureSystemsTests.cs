using System.Collections.Generic;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using Leopotam.EcsProto;
using NUnit.Framework;

namespace _Project.Scripts.Tests.Features.Input
{
    public class InputFeatureSystemsTests : BaseSystemsTests
    {
        private List<ProtoEntity> CreateRequests()
        {
            var list = new List<ProtoEntity>();
            
            list.Add(PlayerInputUtils.CreateEnableRequest(RequestsWorldAspect));
            list.Add(PlayerInputUtils.CreateDisableRequest(RequestsWorldAspect));
            list.Add(PlatformsInputUtils.CreateEnableRequest(RequestsWorldAspect));
            list.Add(PlatformsInputUtils.CreateDisableRequest(RequestsWorldAspect));
            
            return list;
        }

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