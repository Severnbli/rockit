using _Project.Scripts.Runtime.Core.Infrastructure.Requests.World;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Core.Infrastructure.Shared.Systems
{
    public sealed class CloseAppOnCloseAppRequestSystem : IProtoRunSystem
    {
        [DIRequests] private readonly SharedRequestsAspect _srAspect;

        public void Run()
        {
            if (_srAspect.CloseAppRequests.IsEmptySlow()) return;
            
            Application.Quit();
        }
    }
}