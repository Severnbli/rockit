using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Renderer
{
    public class Glitch : ScriptableRendererFeature
    {
        [SerializeField] private Material _material;
        
        [Serializable]
        public class GlitchSettings
        {
            [Range(0, 1)] public float ChromaticGlitch;
            [Range(0, 1)] public float FrameGlitch;
            [Range(0, 1)] public float PixelGlitch;
        }

        public GlitchSettings Settings = new ();

        private GlitchPass _pass;

        public override void Create()
        {
            _pass = new GlitchPass(
                _material,
                Settings.ChromaticGlitch,
                Settings.FrameGlitch,
                Settings.PixelGlitch,
                name
            );
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (_material == null) return;

            renderer.EnqueuePass(_pass);
        }
    }
}