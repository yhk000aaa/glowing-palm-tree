Shader "Custom/Distort"
{
    Properties
        {
            _MainTex ("Texture", 2D) = "white" {}
            _RotScal ("_RotScal", float) = 0
        }

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
        sampler2D _MainTex;
        float _RotScal;
        float _BlackRate;
        
        float4 frag(v2f i) : SV_Target
        {
            float2 uv = i.uv;
            float2 center = float2(0.5, 0.5);
            //计算距离
            float2 dt = uv - center;
            float len = sqrt(dot(dt, dt));
            //根据距离 计算出旋转角
            float theta = -len * _RotScal;

            //旋转矩阵
            float2x2 rot =
            {
                cos(theta), sin(theta),
                -sin(theta) ,cos(theta)
            };
            dt = mul(rot, dt);
            uv = dt + center;
            fixed4 col = tex2D(_MainTex, uv);
            return col * _BlackRate;
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
