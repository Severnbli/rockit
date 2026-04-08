using System.Collections.Generic;
using _Project.Scripts.Runtime.Features.Input.Configs;
using _Project.Scripts.Runtime.Features.Input.Services;
using _Project.Scripts.Runtime.Features.Input.Systems;
using _Project.Scripts.Runtime.Shared.Utils.Input;
using _Project.Scripts.Tests.Shared;
using Leopotam.EcsProto;
using NUnit.Framework;

namespace _Project.Scripts.Tests.Features.Input
{
    public class InputFeatureSystemsTests : BaseSystemsTests
    {
        private PlayerInputService _playerInputService;
        private PlayerInputConfig _playerInputConfig;
        private PlatformsInputService _platformsInputService;
        private PlatformsInputConfig _platformsInputConfig;
        
        [Test]
        public void TestRequestsCreation()
        {
            AssertRequestsEmpty();
            var entities = CreateRequests();
            AssertRequestsEmpty();
            ActivateRequests(entities);
            AssertRequestsOnlyOne();
        }

        private void AddPlatformsSystems(PlatformsInputService service, PlatformsInputConfig config)
        {
            Systems.AddSystem(new DisablePlatformsInputOnRequestSystem(service, config));
            Systems.AddSystem(new EnablePlatformsInputOnRequestSystem(service, config));
        }

        private void AddPlayerInputSystems(PlayerInputService service, PlayerInputConfig config)
        {
            Systems.AddSystem(new DisablePlayerInputOnRequestSystem(service, config));
            Systems.AddSystem(new EnablePlayerInputOnRequestSystem(service, config));
        }

        private void ResetInputFeatureFields()
        {
            var testsConfigs = TestsUtils.GetTestsConfigs();
            _playerInputConfig = testsConfigs.PlayerInputConfig;
            _platformsInputConfig = testsConfigs.PlatformsInputConfig;
            _playerInputService = new PlayerInputService();
            _platformsInputService = new PlatformsInputService();
        }
        
        private List<ProtoEntity> CreateRequests()
        {
            var list = new List<ProtoEntity>();
            
            list.AddRange(CreateEnableRequests());
            list.Add(PlayerInputUtils.CreateDisableRequest(RequestsWorldAspect));
            list.Add(PlatformsInputUtils.CreateDisableRequest(RequestsWorldAspect));
            
            return list;
        }

        private List<ProtoEntity> CreateEnableRequests()
        {
            var list = new List<ProtoEntity>();
            
            list.Add(PlayerInputUtils.CreateEnableRequest(RequestsWorldAspect));
            list.Add(PlatformsInputUtils.CreateEnableRequest(RequestsWorldAspect));
            
            return list;
        }

        private void ActivateRequests(List<ProtoEntity> entities)
        {
            foreach (var entity in entities)
            {
                RequestsWorldAspect.RequestsAspect.ActiveRequestTagPool.Add(entity);
            }
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