Shader "CowsCrasher/Toon"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Main Color", COLOR) = (1,1,1,1)
        _Brightness("Brightness", Range(0,1)) = 0.3
        _Strength("Strength", Range(0,1)) = 0.5
        _LightColor("Light Color", COLOR) = (1,1,1,1)
        _Detail("Detail", Range(0,1)) = 0.3
        _Value("Value", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags 
        {
            "RenderType" = "Opaque"
            "RenderPipeline" = "UniversalPipeline"
            "LightMode" = "UniversalForward"
        }

        Pass
        {            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldNormal: NORMAL;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _LightColor;
            float4 _Value;
            float _Brightness;
            float _Strength;
            float _Detail;

            float Toon(float3 normal, float3 lightDir) {
                float NdotL = max(0.0,dot(normalize(normal), normalize(lightDir)));
                return floor(NdotL / _Detail);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.color = v.color;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                const float4 light = _LightColor * _Strength;
                const float3 fastFixForWebGL = float3(0.3, 0.9, -0.2);
                float4 col = tex2D(_MainTex, i.uv) * _Color;
               
                //float3 lightPoint = _WorldSpaceLightPos0.xyz;
                col *= Toon(i.worldNormal, fastFixForWebGL) * light + _Brightness;
                return col * i.color;
            }
            ENDCG
        }
        
        UsePass "Hidden/CowsCrasher/ToonOutline/OUTLINE"
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}