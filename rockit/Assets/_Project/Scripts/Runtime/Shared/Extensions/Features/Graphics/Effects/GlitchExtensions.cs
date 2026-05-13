using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types;

namespace _Project.Scripts.Runtime.Shared.Extensions.Features.Graphics.Effects
{
    public static class GlitchExtensions
    {
        public static void SetValuesFromSettings(this GlitchService service, GlitchSettings settings)
        {
            service.Chromatic01 = settings.ChromaticGlitch;
            service.Frame01 = settings.FrameGlitch;
            service.Pixel01 = settings.PixelGlitch;
        }
    }
}