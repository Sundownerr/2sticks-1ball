Shader "Custom/GradientForcefield"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _HighlightPosition ("Highlight Position", Vector) = (0,0,0,0)
        _HighlightRadius ("Highlight Radius", Range(0, 1)) = 0.5
        _HighlightColor ("Highlight Color", Color) = (1,0,0,1)
        _HighlightDirection ("Highlight Direction", Vector) = (0,1,0,0)
        _BlendAmount ("Blend Amount", Range(0, 1)) = 0.5
        _Emission ("Emission", Range(0, 1)) = 0.0
    }
 
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Opaque"}
        LOD 100
 
        CGPROGRAM
        #pragma surface surf Standard

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal;
            float3 worldPos;
        };
 
        sampler2D _MainTex;
        float4 _Color;
        float3 _HighlightPosition;
        float _HighlightRadius;
        float4 _HighlightColor;
        float3 _HighlightDirection;
        float _BlendAmount;
        float _Emission;
 
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Calculate dot product between surface normal and highlight direction
            float dotProduct = dot(normalize(IN.worldNormal), normalize(_HighlightDirection));
 
            // Highlight only pixels with dot product > 0
            if (dotProduct > 0)
            {
                // Calculate distance from current pixel to highlight position
                float dist = distance(IN.worldPos, _HighlightPosition);
                float alpha = 1.0 - saturate((dist - _HighlightRadius) / (2.0 * _HighlightRadius));
                alpha = pow(alpha, 2.0);
 
                // Calculate blend factor based on dot product and blend amount
                float blendFactor = dotProduct * _BlendAmount;
 
                // Apply highlight color and alpha to diffuse color
                float4 highlight = _HighlightColor * alpha;
                o.Albedo = lerp(_Color.rgb, highlight.rgb, blendFactor);
                o.Alpha = lerp(_Color.a, highlight.a, blendFactor);

                // Add emission to the blended color
                o.Emission = lerp(0.0, _Emission, blendFactor);
            }
            else
            {
                // Use regular diffuse color for pixels with dot product <= 0
                o.Albedo = _Color.rgb;
                o.Alpha = _Color.a;
                o.Emission = 0.0;
            }
        }
        ENDCG
    }
 
    FallBack "Standard"
}
