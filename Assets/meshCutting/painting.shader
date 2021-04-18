Shader "Unlit/painting"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
		v2f o;
		o.worldPos = mul(unity_ObjectToWorld, v.vertex);
		o.uv = v.uv;
		float4 uv = float4(0, 0, 0, 1);
		uv.xy = float2(1, _ProjectionParams.x) * (v.uv.xy * float2( 2, 2) - float2(1, 1));
		o.vertex = uv; 
		return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }

	    v2f vert (appdata v)
	    {
	    }

            ENDCG
        }
    }
}
