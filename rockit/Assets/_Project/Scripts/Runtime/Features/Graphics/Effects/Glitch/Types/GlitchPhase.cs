using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types
{
    [Serializable]
    public sealed class GlitchPhase
    {
        [Range(0,1)] public float ProgressOfPassage01;
        public float Timeout;
        public float Delay;
        public GlitchSettings GlitchSettings;
    }
}