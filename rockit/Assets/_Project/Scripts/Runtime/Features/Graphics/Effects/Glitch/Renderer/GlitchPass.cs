using _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Types;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace _Project.Scripts.Runtime.Features.Graphics.Effects.Glitch.Renderer
{
    internal class GlitchPass : ScriptableRenderPass
    {
        private static readonly int AmountId = Shader.PropertyToID("_Amount");
        private static readonly int FrameId = Shader.PropertyToID("_Frame");
        private static readonly int PixelId = Shader.PropertyToID("_Pixel");

        private const string FrameKeyword = "FRAME";
        private const string PixelKeyword = "PIXEL";

        private readonly Material _material;
        private readonly GlitchSettings _settings;
        private readonly string _tag;

        private readonly Vector2 _rand1 = new (5.0f,   1.0f);
        private readonly Vector2 _rand2 = new (31.0f,  1.0f);
        private readonly Vector2 _randMul2 = new (127.1f, 311.7f);

        private class PassData
        {
            public TextureHandle Src;
            public TextureHandle Dst;
            public Material Material;
        }

        public GlitchPass(Material material, GlitchSettings settings, string tag)
        {
            _material = material;
            _settings = settings;
            _tag = tag;
        }
        
        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            var resourceData = frameData.Get<UniversalResourceData>();

            if (!resourceData.activeColorTexture.IsValid())
            {
                return;
            }

            UpdateMaterial();

            var srcDesc = renderGraph.GetTextureDesc(resourceData.activeColorTexture);
            srcDesc.name = "_FastGlitchTempCopy";
            srcDesc.clearBuffer = false;

            var tempHandle = renderGraph.CreateTexture(srcDesc);

            using (var builder = renderGraph.AddRasterRenderPass<PassData>(_tag, out var passData))
            {
                passData.Src = resourceData.activeColorTexture;
                passData.Dst = tempHandle;
                passData.Material = _material;

                builder.UseTexture(passData.Src, AccessFlags.Read);
                builder.SetRenderAttachment(passData.Dst, 0, AccessFlags.Write);

                builder.SetRenderFunc(static (PassData data, RasterGraphContext ctx) =>
                {
                    Blitter.BlitTexture(ctx.cmd, data.Src, new Vector4(1, 1, 0, 0), data.Material, 0);
                });
            }

            using (var builder = renderGraph.AddRasterRenderPass<PassData>(_tag + "_copyback", out var passData))
            {
                passData.Src = tempHandle;
                passData.Dst = resourceData.activeColorTexture;
                passData.Material = null;

                builder.UseTexture(passData.Src, AccessFlags.Read);
                builder.SetRenderAttachment(passData.Dst, 0, AccessFlags.Write);

                builder.SetRenderFunc(static (PassData data, RasterGraphContext ctx) =>
                {
                    Blitter.BlitTexture(ctx.cmd, data.Src, new Vector4(1, 1, 0, 0), 0, false);
                });
            }
        }

        private void UpdateMaterial()
        {
            if (_material == null) return;

            var t = Time.realtimeSinceStartup;

            if (_settings.ChromaticGlitch != 0f)
            {
                var a = (1f + Mathf.Sin(t *  6f))
                        * (0.5f + Mathf.Sin(t * 16f) * 0.25f)
                        * (0.5f + Mathf.Sin(t * 19f) * 0.25f)
                        * (0.5f + Mathf.Sin(t * 27f) * 0.25f);
                _material.SetFloat(AmountId, _settings.ChromaticGlitch * Mathf.Pow(a, 3f) * 0.5f);
            }
            else
            {
                _material.SetFloat(AmountId, 0f);
            }

            if (_settings.FrameGlitch != 0f)
            {
                _material.SetFloat(FrameId, (1f + Mathf.Cos(t * 80f)) * 0.02f * _settings.FrameGlitch);
                _material.EnableKeyword(FrameKeyword);
            }
            else
            {
                _material.DisableKeyword(FrameKeyword);
            }

            if (_settings.PixelGlitch != 0f)
            {
                var b = Mathf.Sin(Vector2.Dot(_rand1 * Mathf.Floor(t * 12f), _randMul2)) * 43758.5453123f;
                var c = Mathf.Sin(Vector2.Dot(_rand2 * Mathf.Floor(t * 12f), _randMul2)) * 43758.5453123f;
                _material.SetVector(PixelId, new Vector2(
                    (b - Mathf.Floor(b)) * _settings.PixelGlitch * 0.1f,
                    (c - Mathf.Floor(c)) * _settings.PixelGlitch * 0.1f));
                _material.EnableKeyword(PixelKeyword);
            }
            else
            {
                _material.DisableKeyword(PixelKeyword);
            }
        }
    }
}