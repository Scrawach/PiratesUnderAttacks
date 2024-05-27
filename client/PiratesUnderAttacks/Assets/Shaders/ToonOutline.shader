Shader "Hidden/CowsCrasher/ToonOutline"
{
	SubShader
	{
		Tags 
		{
			"RenderType" = "Opaque"
		}

		Pass
		{	
			Name "Outline"
			Cull Front



		    CGPROGRAM
		    #pragma vertex vert
		    #pragma fragment frag

		    #include "UnityCG.cginc"

		    struct appdata
		    {
		        float4 vertex : POSITION;
		        float3 normal : NORMAL;
		    };

		    struct v2f
		    {
		        float4 vertex : SV_POSITION;
		    };

		    static const half4 OUTLINE_COLOR = half4(0,0,0,0);
		    static const float OUTLINE_WIDTH = 0.03;

		    v2f vert (appdata v)
		    {		    	
		        v.vertex.xyz += v.normal * OUTLINE_WIDTH;
		        v2f o;
		        o.vertex = UnityObjectToClipPos(v.vertex);
		        return o;
		    }

		    fixed4 frag () : SV_Target
		    {
		        return OUTLINE_COLOR;
		    }
		    
		    ENDCG
		}
	}
}