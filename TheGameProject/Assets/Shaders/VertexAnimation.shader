Shader "Custom/VertexAnimation"
{
     Properties {
         _MainTex ("Albedo (RGB)", 2D) = "white" {}
         _Value1 ("Value 1", Range(0,100)) = 1.0
         _Value2 ("Value 2", Range(0,100)) = 1.0
         _Value3 ("Value 3", Range(0,100)) = 1.0
     }
     SubShader {
         Tags { "RenderType"="Opaque" }
         LOD 200
        
         CGPROGRAM
         // Physically based Standard lighting model, and enable shadows on all light types
         #pragma surface surf Standard vertex:vert fullforwardshadows
 
         // Use shader model 3.0 target, to get nicer looking lighting
         #pragma target 3.0
 
         sampler2D _MainTex;
 
         struct Input {
             float2 uv_MainTex;
         };
 
         float _Value1;
         float _Value2;
         float _Value3;
 
         void surf (Input IN, inout SurfaceOutputStandard o) {
             fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
             o.Albedo = c.rgb;            
         }
        
         void vert (inout appdata_full v) {
            v.vertex.x += cos((v.vertex.y + _Time * _Value3) * _Value2) * _Value1;
         }
 
         ENDCG
     }
     FallBack "Diffuse"
}
