Shader "Custom/GaussBlurFlower" {
    Properties{
    _MainTex("Albedo (RGB)", 2D) = "white" {}
    _Plansize("画布比例", float) = 1
    _Texturesize("图片比例", float) = 1
        _SizeZT("缩放zT", Range(0, 20)) = 0
        _Whith("行数", float) = 1
        _Hight("列数", float) = 1
        _Tim("Tim", float) = 1
        _A("透明度", Range(0, 1)) = 1
        _style("样式", int) = 0//0单旋 1散开 2回旋 3慢旋 4散聚
    }
        SubShader{
            Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
            LOD 100
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Pass{
            CGPROGRAM

    #pragma exclude_renderers gles
    #pragma vertex vert
    #pragma fragment frag
    #include "UnityCG.cginc"

    sampler2D _MainTex;
    int _RepeatNUM;
    float _Centrifuge;
    float _Plansize;
    float _Texturesize;

    float _ElaT;

    float _Dx;
    float _Dy;

    float _Size;
    float _Size2;
    float _SizeZT;
    float K;

    float _Whith;
    float _Hight;
    
    float _JZ, _JZ2, _Tim;
    float _A;
    int _style;
    struct appdata
    {
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
    };
    struct v2f {
        float4 pos : SV_POSITION;
        float2 uv : TEXCOORD0;
    };


    v2f vert(appdata_img v)
    {
        v2f o;
        o.pos = UnityObjectToClipPos(v.vertex);
        o.uv = v.texcoord.xy;
        return o;
    }

    float4 Repeatpicture(float2 uv)
    {
        float4 color1 = tex2D(_MainTex, uv);
        if (uv.x<0 || uv.x>1 || uv.y<0 || uv.y>1) {
            color1.a = 0;
        }
        uv = uv + 0.2;
        float4 color2 = tex2D(_MainTex, uv);
        if (uv.x<0 || uv.x>1 || uv.y<0 || uv.y>1) {
            color2.a = 0;
        }
        float4 colorTmp = color1*(1 - color2.a)*color1.a + color2*color2.a;
        return colorTmp;
    }
    float BezierADm(float tim1, float tim2, float na, float nb, float ka, float kb, float Time)//时间从tim1到tim2，数值从na到nb。曲线斜率ka，kb。总时间Time
    {
        float num;
        float L = (tim2 - tim1) / 2.0f;
        if (Time < tim1)
        {
            num = na;
        }
        else
        {
            if (Time <= tim2)
            {
                float t = (Time - tim1) / (tim2 - tim1);
                float3 p0 = float3(tim1, na, 0);
                float3 p1 = float3(L, tan(ka) * L, 0);
                float3 p2 = float3(-L, tan(kb) * L, 0);
                float3 p3 = float3(tim2, nb, 0);
                float3 b0 = float3(0, 0, 0);
                float3 b1 = float3(0, 0, 0);
                float3 b2 = float3(0, 0, 0);
                float3 b3 = float3(0, 0, 0);
                float Ax, Ay, Az, Bx, By, Bz, Cx, Cy, Cz;

                Cx = 3.0 * ((p0.x + p1.x) - p0.x);
                Bx = 3.0 * ((p3.x + p2.x) - (p0.x + p1.x)) - Cx;
                Ax = p3.x - p0.x - Cx - Bx;
                Cy = 3.0 * ((p0.y + p1.y) - p0.y);
                By = 3.0 * ((p3.y + p2.y) - (p0.y + p1.y)) - Cy;
                Ay = p3.y - p0.y - Cy - By;
                Cz = 3.0 * ((p0.z + p1.z) - p0.z);
                Bz = 3.0 * ((p3.z + p2.z) - (p0.z + p1.z)) - Cz;
                Az = p3.z - p0.z - Cz - Bz;
                b0 = p0;
                b1 = p1;
                b2 = p2;
                b3 = p3;
                float t2 = t * t;
                float t3 = t * t * t;
                float x = Ax * t3 + Bx * t2 + Cx * t + p0.x;
                float y = Ay * t3 + By * t2 + Cy * t + p0.y;
                float z = Az * t3 + Bz * t2 + Cz * t + p0.z;
                num = y;

            }
            else
            {
                num = nb;
            }
        }
        return num;
    }
    void funtion() {
        
        if (_style==0) {
            if (_Tim<22) {
                if (_Tim<12) {
                    if (_Tim<2) {
                        _ElaT = 1.056;
                        _Size2 = lerp(0, 0.2, _Tim / 12.0);
                        _Centrifuge = 0.131;
                        _JZ = 0.893;
                        _JZ2 = 0;
                    }
                    else {
                        _ElaT = lerp(1.056, 0.056, (_Tim - 2) / 20.0);
                        _Size2 = lerp(0, 0.2, _Tim / 12.0);
                        _Centrifuge = lerp(0.131, 0.06, (_Tim - 2) / 10.0);
                        _JZ = lerp(0.893, 1, (_Tim - 2) / 10.0);
                        _JZ2 = lerp(0, -0.0019, (_Tim - 2) / 10.0);
                    }
                }
                else {
                    _ElaT = lerp(1.056, 0.056, (_Tim - 2) / 20.0);
                    _Size2 = lerp(0.2, 0, (_Tim - 12) / 12.0);
                    _Centrifuge = lerp(0.06, 0.131, (_Tim - 12) / 10.0);
                    _JZ = lerp(1, 0.893, (_Tim - 12) / 10.0);
                    _JZ2 = lerp(-0.0019, 0, (_Tim - 12) / 10.0);
                }
            }
            else {
                _ElaT = 0.056;
                _Size2 = lerp(0.2, 0, (_Tim - 12) / 12.0);
                _Centrifuge = 0.131;
                _JZ = 0.893;
                _JZ2 = 0;
            }
        }
        else if (_style == 1) {
            if (_Tim<10) {
                _ElaT = 0.3325;
                _Size2 = lerp(0, 0.1, _Tim / 10.0);
                _Centrifuge = 0.17;
                _JZ = 0.82;
            }
            else {
                _ElaT = lerp(0.3325, 0.4, (_Tim - 10.0) / 14.0);
                _Size2 = lerp(0.1, 0.2535, (_Tim - 10.0) / 14.0);
                _Centrifuge = BezierADm(10, 24, 0.17, 2.6, 0, -0.4, _Tim);
                _JZ = 1 - ((_Tim - 10.0 - 100) / -93.46) + 0.89;

            }
        }
        else if (_style == 2) {
            if (_Tim<22) {
                if (_Tim<12) {
                    if (_Tim<2) {
                        _ElaT = 1.056;
                        //_Size2 = lerp(0, 0.2, _Tim / 12.0);
                        _Size2 = BezierADm(0, 12, 0, 0.2, 0.02, 0, _Tim);
                        _Centrifuge = 0.131;
                        _JZ = 0.893;
                        _JZ2 = 0;
                    }
                    else {
                        //_ElaT = lerp(1.056, 0.056, (_Tim - 2) / 20.0);
                        _ElaT = BezierADm(2, 12, 1.056, 0.5, 0, 0, _Tim);
                        //_Size2 = lerp(0, 0.2, _Tim / 12.0);
                        _Size2 = BezierADm(0, 12, 0, 0.2, 0.02, 0, _Tim);
                        _Centrifuge = lerp(0.131, 0.06, (_Tim - 2) / 10.0);
                        _JZ = lerp(0.893, 1, (_Tim - 2) / 10.0);
                        _JZ2 = lerp(0, -0.0019, (_Tim - 2) / 10.0);
                    }
                }
                else {
                    //_ElaT = lerp(1.056, 0.056, (_Tim - 2) / 20.0);
                    _ElaT = BezierADm(12, 22, 0.5, 1.056, 0, 0, _Tim);
                    //_Size2 = lerp(0.2, 0, (_Tim - 12) / 12.0);
                    _Size2 = BezierADm(12, 24, 0.2, 0, 0, 0.02, _Tim);
                    _Centrifuge = lerp(0.06, 0.131, (_Tim - 12) / 10.0);
                    _JZ = lerp(1, 0.893, (_Tim - 12) / 10.0);
                    _JZ2 = lerp(-0.0019, 0, (_Tim - 12) / 10.0);
                }
            }
            else {
                _ElaT = 0.056;
                //_Size2 = lerp(0.2, 0, (_Tim - 12) / 12.0);
                _Size2 = BezierADm(12, 24, 0.2, 0, 0, 0.02, _Tim);
                _Centrifuge = 0.131;
                _JZ = 0.893;
                _JZ2 = 0;
            }
        }
        else if (_style == 3) {
            if (_Tim<22) {
                if (_Tim<12) {
                    if (_Tim<2) {
                        _ElaT = BezierADm(0, 24, 1.056, 0.8, 0, 0, _Tim);
                        _Size2 = BezierADm(0, 12, 0, 0.2, 0.02, 0, _Tim);
                        _Centrifuge = 0.131;
                        _JZ = 0.893;
                        _JZ2 = 0;
                    }
                    else {
                        _ElaT = BezierADm(0, 24, 1.056, 0.8, 0, 0, _Tim);
                        _Size2 = BezierADm(0, 12, 0, 0.2, 0.02, 0, _Tim);
                        _Centrifuge = lerp(0.131, 0.06, (_Tim - 2) / 10.0);
                        _JZ = lerp(0.893, 1, (_Tim - 2) / 10.0);
                        _JZ2 = lerp(0, -0.0019, (_Tim - 2) / 10.0);
                    }
                }
                else {
                    _ElaT = BezierADm(0, 24, 1.056, 0.8, 0, 0, _Tim);
                    _Size2 = BezierADm(12, 24, 0.2, 0, 0, 0.02, _Tim);
                    _Centrifuge = lerp(0.06, 0.131, (_Tim - 12) / 10.0);
                    _JZ = lerp(1, 0.893, (_Tim - 12) / 10.0);
                    _JZ2 = lerp(-0.0019, 0, (_Tim - 12) / 10.0);
                }
            }
            else {
                _ElaT = BezierADm(0, 24, 1.056, 0.8, 0, 0, _Tim);
                _Size2 = BezierADm(12, 24, 0.2, 0, 0, 0.02, _Tim);
                _Centrifuge = 0.131;
                _JZ = 0.893;
                _JZ2 = 0;
            }
        }
        else if (_style == 4) {
            float _Tt = 24 - _Tim;
            if (_Tt<10) {
                _ElaT = 0.3325;
                _Size2 = lerp(0, 0.1, _Tt / 10.0);
                _Centrifuge = 0.17;
                _JZ = 0.82;
            }
            else {
                _ElaT = lerp(0.3325, 0.4, (_Tt - 10.0) / 14.0);
                _Size2 = lerp(0.1, 0.2535, (_Tt - 10.0) / 14.0);
                _Centrifuge = BezierADm(10, 24, 0.17, 2.6, 0, -0.4, _Tt);
                _JZ = 1 - ((_Tt - 10.0 - 100) / -93.46) + 0.89;

            }
        }
        else{
            if (_Tim<22) {
                if (_Tim<12) {
                    if (_Tim<2) {
                        _ElaT = 1.056;
                        _Size2 = lerp(0, 0.2, _Tim / 12.0);
                        _Centrifuge = 0.131;
                        _JZ = 0.893;
                        _JZ2 = 0;
                    }
                    else {
                        _ElaT = lerp(1.056, 0.056, (_Tim - 2) / 20.0);
                        _Size2 = lerp(0, 0.2, _Tim / 12.0);
                        _Centrifuge = lerp(0.131, 0.06, (_Tim - 2) / 10.0);
                        _JZ = lerp(0.893, 1, (_Tim - 2) / 10.0);
                        _JZ2 = lerp(0, -0.0019, (_Tim - 2) / 10.0);
                    }
                }
                else {
                    _ElaT = lerp(1.056, 0.056, (_Tim - 2) / 20.0);
                    _Size2 = lerp(0.2, 0, (_Tim - 12) / 12.0);
                    _Centrifuge = lerp(0.06, 0.131, (_Tim - 12) / 10.0);
                    _JZ = lerp(1, 0.893, (_Tim - 12) / 10.0);
                    _JZ2 = lerp(-0.0019, 0, (_Tim - 12) / 10.0);
                }
            }
            else {
                _ElaT = 0.056;
                _Size2 = lerp(0.2, 0, (_Tim - 12) / 12.0);
                _Centrifuge = 0.131;
                _JZ = 0.893;
                _JZ2 = 0;
            }
        }

    }

    //自转
    float2 RotUV(float2 uv,float _El)
    {
        float _Px = 0.5;
        float _Py = 0.5;
        float _Ela = (_El+0.09)*6.28318;
        float2 uv1 = float2 ((uv.x - _Px)*cos(_Ela) - (uv.y - _Py)*sin(_Ela) + _Px, (uv.x - _Px)*sin(_Ela) + (uv.y - _Py)*cos(_Ela) + _Py);
        return uv1;
    }
    //分辨率自适应计算
    float2 resolutionUV(float2 uv,float P,float T)
    {
        float k = P/T;
        float2 uv1;
        
        if (k>1) {
            uv1 = float2((uv.x - 0.5) * k + 0.5, uv.y);
        }
        else {
            uv1 = float2(uv.x, (uv.y - 0.5) / k + 0.5);
        }
        return uv1;
    }
    //平移
    float2 translationUV(float2 uv,float x,float y)
    {
        float2 uv1 = float2(uv.x - x, uv.y - y);
        return uv1;
    }
    
    //缩放
    float2 scalingUV(float2 uv,float s) {
        float2 uv1 = float2((uv.x - 0.5)/s + 0.5, (uv.y - 0.5)/s + 0.5);
        return uv1;
    }

    //重叠
    float4 Repeatpicture2(float2 uvv)
    {
        float4 colorTmp = (0, 0, 0, 0);
        for (int i = 0; i < _RepeatNUM; i++) {
            float ll= _JZ*6.28+2.15;
            float Lx;
            float Ly;

            Lx = (sin((i / (float)_RepeatNUM)*6.28 + ll)*(10 * _Centrifuge) / 100.0)/*+abs ((sin((i / (float)_RepeatNUM)*6.28 + ll)*(10 * 0.2) / 100.0))*01.55*/;
            Ly = (cos((i / (float)_RepeatNUM)*6.28 + ll)*(10 * _Centrifuge) / 100.0)/*+ abs((cos((i / (float)_RepeatNUM)*6.28 + ll)*(10 * 0.2) / 100.0))*01.55*/;
            float sas;
            if(i>5){
                sas = 0;
            }else{
                sas = _JZ2;
            }
            sas = _JZ2;
            float2 uv = translationUV(resolutionUV(RotUV(scalingUV(translationUV(uvv.xy, Lx, Ly), _Size), (_ElaT- sas*(_RepeatNUM-i))+i/ (float)_RepeatNUM),1, _Texturesize),_Dx, _Dy);
            float4 color = tex2D(_MainTex, uv);
            if (uv.x<0 || uv.x>1 || uv.y<0 || uv.y>1) {
                color.a = 0;
            }
            colorTmp = colorTmp*(1 - color.a)*colorTmp.a + color*color.a;
        }
        return colorTmp;
    }
    //重叠fb
    float4 Repeatpicture3(float2 uvv)
    {
        float4 colorTmp = (0, 0, 0, 0);
        for (int i = 1; i < _RepeatNUM; i++) {
            float ll = 3.28;
            float Lx = (sin((i / (float)_RepeatNUM)*6.28 + ll)*(i*_Centrifuge) / 100.0);
            float Ly = (cos((i / (float)_RepeatNUM)*6.28 + ll)*(i*1.3*_Centrifuge) / 100.0);
            float2 uv = translationUV(resolutionUV(RotUV(scalingUV(translationUV(uvv.xy, Lx, Ly), _Size),_ElaT + i /(float)_RepeatNUM), 1, _Texturesize), _Dx, _Dy);
            float4 color = tex2D(_MainTex, uv);
            if (uv.x<0 || uv.x>1 || uv.y<0 || uv.y>1) {
                color.a = 0;
            }
            colorTmp = colorTmp*(1 - color.a)*colorTmp.a + color*color.a;
        }
        return colorTmp;
    }
    //四面镜像
    float2 Fourimages(float2 uv) {
        float2 uv1 = abs(uv.xy - 0.5) * 2;
        return uv1;
    }
    //行列变换
    float2 arrayUV(float2 uv,float w,float h) {

        float2 uv1 = abs(float2(uv.x % (1 / w), uv.y % (1 / h)));
        float2 uv2 = float2(uv1.x + (w - 1) / (2 * w), uv1.y + (h - 1) / (2 * h));
        return uv2;
    }
    
    
    half4 frag(v2f i) : SV_Target
    {
        _Tim = clamp(_Tim,0,24);
    
    _RepeatNUM = 11;//重复数
    _Dy = 0;//Local位移y
    
    funtion();
    _Size = _Size2;
    
    
    float2 uv = scalingUV(resolutionUV(scalingUV(translationUV(Fourimages(arrayUV(i.uv.xy, _Whith, _Hight)), -0.5, -0.5), 2),_Plansize,1), _SizeZT);
    //float2 uv = i.uv.xy;
    


    float4 color = Repeatpicture2(uv);
    //float4 color = tex2D(_MainTex, uv);

    if (uv.x<0||uv.x>1||uv.y<0||uv.y>1) {
        color.a = 0;
    }
    return fixed4(color.r, color.g, color.b, color.a*_A);
        
    }
        ENDCG
    }
    }
        FallBack "Diffuse"
}

