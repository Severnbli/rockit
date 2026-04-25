using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using Leopotam.EcsProto;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Systems
{
    public sealed class UpdateGlitchServiceFeatureOnRunSystem : IProtoRunSystem
    {
        private readonly GlitchService _gService;

        public UpdateGlitchServiceFeatureOnRunSystem(GlitchService gService)
        {
            _gService = gService;
        }

        public void Run()
        {
            var gSettings = _gService.Feature.Settings;

            gSettings.ChromaticGlitch = _gService.Chromatic01;
            gSettings.FrameGlitch = _gService.Frame01;
            gSettings.PixelGlitch = _gService.Pixel01;
        }
    }
}