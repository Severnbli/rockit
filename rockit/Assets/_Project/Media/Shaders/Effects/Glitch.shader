Shader "Glitch"
{
    Properties
    {
        _MainTex("Base (RGB)", 2D) = "" {}
    }

    HLSLINCLUDE

    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
    #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

    half _Amount;
    half _Frame;
    half2 _Pixel;

    half r(half2 v)
    {
        return frac(sin(dot(v * floor(_Time.y * 12.0h), half2(127.1h, 311.7h))) * 43758.5453123h);
    }

    half4 frag(Varyings i) : SV_Target
    {
        UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

        half2 uv  = i.texcoord;
        half uvR = uv.x + _Amount;
        half uvB = uv.x - _Amount;

        #ifdef FRAME
            half frameShift = sin(uv.y * 10.0h + _Time.y)
                            * step(0.3h, sin(_Time.y + 4.0h * _CosTime.w))
                            * _Frame;
            uv.x += frameShift;
            uvR  += frameShift;
            uvB  += frameShift;
        #endif

        #ifdef PIXEL
            half4 uv1a = floor(half4(i.texcoord * half2(24.0h, 9.0h),
                                     i.texcoord * half2(8.0h,  4.0h)));
            half lineNoise = pow(r(uv1a.xy), 8.0h) * pow(r(uv1a.zw), 3.0h);
            uv.x  += lineNoise * _Pixel.x;
            uvB   -= lineNoise * _Pixel.y;
        #endif

        half r = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, half2(uvR, uv.y)).r;
        half g = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, uv).g;
        half b = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, half2(uvB, uv.y)).b;

        return half4(r, g, b, 1.0h);
    }

    ENDHLSL

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            Name "Glitch"
            ZTest Always
            Cull Off
            ZWrite Off

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment frag
            #pragma shader_feature_local FRAME
            #pragma shader_feature_local PIXEL
            #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO STEREO_INSTANCING_ON
            ENDHLSL
        }
    }

    Fallback off
}
