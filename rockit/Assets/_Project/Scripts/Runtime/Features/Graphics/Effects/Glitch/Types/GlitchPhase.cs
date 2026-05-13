using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types
{
    [Serializable]
    public sealed class GlitchPhase
    {
        public float ProgressOfPassage;
        public float Duration;
        [Range(0,1)] public float Frequency01;
        public GlitchSettings GlitchSettings;
    }
}