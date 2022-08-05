Shader "Custom/Scratches"
{
        CGINCLUDE

        #pragma exclude_renderers d3d11_9x
        #pragma target 3.0
        #include "UnityCG.cginc"
        struct a2f
        {
            float4 vert : POSITION;
            float4 texcoord : TEXCOORD0;
        };

        struct v2f
        {
            float4 pos : SV_POSITION;
            float2 uv : TEXCOORD0;
        };


        v2f vert(a2f v)
        {
            v2f o;
            o.pos = UnityObjectToClipPos(v.vert);
            o.uv = v.texcoord.xy;
            return o;
        }
        //从外部获取随机数，让画面达到随机变换的效果

        float _Intensity;
        sampler2D _MainTex;
        sampler2D _GrainTex;
        float _OffsetX;
        float _OffsetY;
        
        float4 frag(v2f i) : SV_Target
        {
            float3 color = tex2D(_MainTex, i.uv).rgb;

            float3 grain =  tex2D(_GrainTex, i.uv + float2(_OffsetX, _OffsetY)).rgb;
            color += float3(grain.r, grain.r, grain.r) * _Intensity;
            return float4(color.r, color.g, color.b, 1);
        }

    ENDCG

    SubShader
    {
        //由于是屏幕渲染，所以剔除和深度都可以关
        Cull Back ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM

                #pragma vertex vert
                #pragma fragment frag

            ENDCG
        }

    }
}