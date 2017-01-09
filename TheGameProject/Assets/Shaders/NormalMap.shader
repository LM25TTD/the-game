Shader "Custom/NormalMap" {
	Properties {
		_MainTex ("Base Texture", 2D) = "white" {}
		_BumpTex ("Bumpmap Texture", 2D) = "bump" {}
	}

	//Just a copy from Unity example
	//to see the effects.
	//Please, disconsider for test porpose
	SubShader {
		Tags { "RenderType"="Opaque" }
		 CGPROGRAM
         #pragma surface surf Lambert

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpTex;
		};

		sampler2D _MainTex;
		sampler2D _BumpTex;

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
        	o.Normal = UnpackNormal (tex2D (_BumpTex, IN.uv_BumpTex));
		}

		ENDCG
	}
	FallBack "Diffuse"
}
