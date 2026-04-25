using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using Leopotam.EcsProto;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public sealed class ClampGlitchServiceValuesFieldsOnRunSystem : IProtoRunSystem
    {
        private readonly GlitchService _gService;

        public ClampGlitchServiceValuesFieldsOnRunSystem(GlitchService gService)
        {
            _gService = gService;
        }

        public void Run()
        {
            _gService.Chromatic01 = Mathf.Clamp01(_gService.Chromatic01);
            _gService.Frame01 = Mathf.Clamp01(_gService.Frame01);
            _gService.Pixel01 = Mathf.Clamp01(_gService.Pixel01);
        }
    }
}