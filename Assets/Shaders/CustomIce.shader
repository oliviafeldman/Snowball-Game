Shader "Custom/IceShader"
{
    Properties
    {
        _Color ("Color", Color) = (0.8, 0.9, 1, 0.5)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Glossiness ("Glossiness", Range(0,1)) = 0.9
        _Specular ("Specular", Range(0,1)) = 0.5
        _RefractionStrength ("Refraction Strength", Range(0, 0.1)) = 0.02
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 300
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        CGPROGRAM
        // Use BlinnPhong lighting model
        #pragma surface surf BlinnPhong alpha:fade

        sampler2D _MainTex;
        sampler2D _BumpMap;
        fixed4 _Color;
        half _Glossiness;
        half _Specular;
        float _RefractionStrength;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float3 viewDir;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Sample the main texture and apply color tint
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb; // Base color
            o.Alpha = c.a;    // Transparency

            // Apply normal mapping
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

            // Set specular and glossiness for shininess
            o.Specular = _Specular;
            o.Gloss = _Glossiness;

            // Simple refraction effect
            float eta = 1.0 / 1.309; // Approximate index of refraction for ice
            float3 refractedDir = refract(-normalize(IN.viewDir), o.Normal, eta);
            float2 refractedUV = IN.uv_MainTex + refractedDir.xy * _RefractionStrength;
            fixed4 refractedColor = tex2D(_MainTex, refractedUV);

            // Mix original and refracted color for emission
            o.Emission = refractedColor.rgb * 0.5;
        }
        ENDCG
    }
    FallBack "Transparent/Diffuse"
}
