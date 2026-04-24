using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch
{
    public class Glitch : ScriptableRendererFeature
    {
        [Serializable]
        public class GlitchSettings
        {
            public Material BlitMaterial;
            [Range(0, 1)] public float ChromaticGlitch;
            [Range(0, 1)] public float FrameGlitch;
            [Range(0, 1)] public float PixelGlitch;
        }

        public GlitchSettings settings = new ();

        private GlitchPass m_Pass;

        public override void Create()
        {
            m_Pass = new GlitchPass(
                settings.BlitMaterial,
                settings.ChromaticGlitch,
                settings.FrameGlitch,
                settings.PixelGlitch,
                name
            );
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (settings.BlitMaterial == null) return;

            renderer.EnqueuePass(m_Pass);
        }
    }
}