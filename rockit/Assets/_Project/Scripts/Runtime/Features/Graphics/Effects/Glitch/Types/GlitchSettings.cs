using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types
{
    [Serializable]
    public class GlitchSettings
    {
        [Range(0, 1)] public float ChromaticGlitch;
        [Range(0, 1)] public float FrameGlitch;
        [Range(0, 1)] public float PixelGlitch;
    }
}