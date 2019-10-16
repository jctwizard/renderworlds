// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "RenderScene" 
{
	Properties{
		_RGB("Screen (RGB)", 2D) = "white" {}
		_DEPTH("Depth (RGB)", 2D) = "white" {}
	}
		SubShader{
			Pass {
				CGPROGRAM
				#pragma target 4.0
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				sampler2D _RGB;
				sampler2D _DEPTH;

				struct v2f
				{
					float4 position : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct fragOut
				{
					half4 color : COLOR;
					float depth : DEPTH;
				};

				v2f vert(appdata_base v)
				{
					v2f o;
					o.position = UnityObjectToClipPos(v.vertex);
					o.uv = v.texcoord;
					return o;
				}

				fragOut frag(in v2f i)
				{
					fragOut o;
					o.color = tex2D(_RGB, i.uv);
					o.depth = tex2D(_DEPTH, i.uv);
					return o;
				}
				ENDCG
			}
	}
}