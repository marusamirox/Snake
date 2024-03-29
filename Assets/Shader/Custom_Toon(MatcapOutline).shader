Shader "Custom/Toon(MatcapOutline)" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,1)
		_ShadingColor ("ShadingColor", Vector) = (0,0,0,1)
		_MainTex ("MainTex", 2D) = "white" {}
		_Emission ("Emission", Range(0, 1)) = 0
		_RampThreshold ("RampThreshold", Range(0, 1)) = 0.5
		_RampSmooth ("RampSmooth", Range(0, 1)) = 0.1
		_Matcap ("Matcap", 2D) = "white" {}
		_Matcap_Intensity ("Matcap_Intensity", Range(0, 1)) = 0
		_ShadowColor ("ShadowColor", Vector) = (1,1,1,1)
		_OutlineColor1 ("OutlineColor", Vector) = (1,1,1,1)
		_OutlineWidth1 ("OutlineWidth", Float) = 0.5
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}