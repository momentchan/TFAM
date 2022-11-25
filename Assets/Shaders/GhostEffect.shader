Shader "TFAM/GhostEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GradTex ("Gradient", 2D) = "white" {}
        _FractalTex ("Fractal", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"
            sampler2D _MainTex;
            sampler2D _Source;
            sampler2D _GradTex;
            sampler2D _FractalTex;
            float _DT;

            fixed4 frag (v2f_img i) : SV_Target
            {
                fixed4 prev = tex2D(_MainTex, i.uv);
                fixed fractal = tex2D(_FractalTex, i.uv);
                fixed4 source = (1 - tex2D(_Source, i.uv));
                fixed4 grad = tex2D(_GradTex, float2(source.x,0.5));
                float strength = 1e-1;
                float fadeFactor = 1e-2;

                fixed4 col = fractal * saturate(prev + grad * source * strength - fadeFactor);
                return col;
            }
            ENDCG
        }
    }
}
