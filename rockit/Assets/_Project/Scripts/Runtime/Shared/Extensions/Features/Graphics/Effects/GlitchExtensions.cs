using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Configs;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Services;
using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types;
using UnityEngine;

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

        public static bool TryGetPhaseByProgressOfPassage01(this GlitchConfig config, float pop, out GlitchPhase phase)
        {
            pop = Mathf.Clamp01(pop);
            phase = null;
            
            foreach (var currPhase in config.Phases)
            {
                if (currPhase.ProgressOfPassage > pop) continue;
                
                phase = currPhase;
            }

            return phase != null;
        }
    }
}