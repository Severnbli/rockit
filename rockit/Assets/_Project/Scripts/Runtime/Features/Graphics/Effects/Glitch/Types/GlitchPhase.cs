using System;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types
{
    [Serializable]
    public sealed class GlitchPhase
    {
        public float ProgressOfPassage;
        public float Duration;
        public float Frequency;
        public GlitchSettings GlitchSettings;
    }
}