Shader "Custom/Diffuse Texture" {
    Properties {
      _FirstTex ("First Texture", 2D) = "white" {}
      _SecondTex ("Second Texture", 2D) = "white" {}
    }

    //Nothing special, just based on Unity example with minor change

    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_FirstTex;
          float2 uv_SecondTex;
      };
      sampler2D _FirstTex;
      sampler2D _SecondTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_FirstTex, IN.uv_FirstTex).rgb ;
          o.Albedo += tex2D (_SecondTex, IN.uv_SecondTex).rgb/2;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }