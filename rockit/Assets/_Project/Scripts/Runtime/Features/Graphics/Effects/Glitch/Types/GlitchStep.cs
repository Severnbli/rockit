using System;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types
{
    [Serializable]
    public sealed class GlitchStep
    {
        public float ProgressOfPassage;
        public float Duration;
        public float Frequency;
        public GlitchSettings GlitchSettings;
    }
}