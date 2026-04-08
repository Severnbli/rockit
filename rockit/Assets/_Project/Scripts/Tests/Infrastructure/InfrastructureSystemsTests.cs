using _Project.Scripts.Runtime.Core.Infrastructure.Requests;
using _Project.Scripts.Runtime.Core.Infrastructure.Requests.Systems;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Services;
using _Project.Scripts.Runtime.Core.Infrastructure.Time.Systems;
using _Project.Scripts.Runtime.Core.Systems;
using _Project.Scripts.Runtime.Shared.Extensions;
using _Project.Scripts.Tests.Shared;
using NUnit.Framework;
using UnityEngine;

namespace _Project.Scripts.Tests.Infrastructure
{
    public class InfrastructureSystemsTests : BaseSystemsTests
    {
        [Test]
        public void TestTimeSystems()
        {
            var timeService = new TimeService();
            Systems.AddSystem(new TimeServiceUpdateSystem(timeService));
            
            Systems.Init();
            
            Systems.Run();
            Systems.FixedRun();
            
            Assert.AreEqual(timeService.Time, Time.time);
            Assert.AreEqual(timeService.FixedTime, Time.fixedTime);
            Assert.AreEqual(timeService.DeltaTime, Time.deltaTime);
            Assert.AreEqual(timeService.FixedDeltaTime, Time.fixedDeltaTime);
            Assert.AreEqual(timeService.UnscaledTime, Time.unscaledTime);
            Assert.AreEqual(timeService.UnscaledFixedTime, Time.fixedUnscaledTime);
            Assert.AreEqual(timeService.UnscaledDeltaTime, Time.unscaledDeltaTime);
            Assert.AreEqual(timeService.UnscaledFixedDeltaTime, Time.fixedUnscaledDeltaTime);
        }

        [Test]
        public void TestRequestsSystems()
        {
            Systems.AddSystem(new DelActivatedRequestsSystem());
            Systems.AddSystem(new ActivateRequestsSystem());
            
            Systems.Init();

            var requestAspect = Systems.World().Aspect(typeof(RequestsAspect)) as RequestsAspect;

            requestAspect.CreateRequest();
            requestAspect.CreateRequest(fixedRun: true);

            Assert.AreEqual(requestAspect!.RunNotActivated.LenSlow(), 1);
            Assert.AreEqual(requestAspect!.FixedRunNotActivated.LenSlow(), 1);
            Assert.AreEqual(requestAspect!.RunActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.FixedRunActivated.LenSlow(), 0);
            
            Systems.Run();
            Systems.FixedRun();
            
            Assert.AreEqual(requestAspect!.RunNotActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.FixedRunNotActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.RunActivated.LenSlow(), 1);
            Assert.AreEqual(requestAspect!.FixedRunActivated.LenSlow(), 1);
            
            Systems.Run();
            Systems.FixedRun();
            
            Assert.AreEqual(requestAspect!.RunNotActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.FixedRunNotActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.RunActivated.LenSlow(), 0);
            Assert.AreEqual(requestAspect!.FixedRunActivated.LenSlow(), 0);
        }
    }
}