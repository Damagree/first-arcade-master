// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CC2D/Diffuse/Armor Recolor"
{
	Properties
	{
		_Tint("Tint", Color) = (1,1,1,1)
		_MainTex("MainTex", 2D) = "white" {}
		_ColorMask("Color Mask", 2D) = "black" {}
		_Color1("Color 1", Color) = (0.4980392,0.4980392,0.4980392,1)
		_Color2("Color 2", Color) = (0.4431373,0.4431373,0.4431373,1)
		_Color3("Color 3", Color) = (0.4431373,0.4431373,0.4431373,1)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Off
		CGPROGRAM
		#pragma target 2.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform half4 _Color1;
		uniform sampler2D _ColorMask;
		uniform float4 _ColorMask_ST;
		uniform half4 _Color2;
		uniform half4 _Color3;
		uniform float4 _Tint;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			float4 tex2DNode11 = tex2D( _MainTex, uv_MainTex );
			float2 uv_ColorMask = i.uv_texcoord * _ColorMask_ST.xy + _ColorMask_ST.zw;
			float4 tex2DNode2 = tex2D( _ColorMask, uv_ColorMask );
			float4 lerpResult42 = lerp( ( half4(0.4980392,0.4980392,0.4980392,1) * tex2DNode11 ) , ( _Color1 * tex2DNode11 ) , tex2DNode2.r);
			float4 lerpResult43 = lerp( lerpResult42 , ( _Color2 * tex2DNode11 ) , tex2DNode2.g);
			float4 lerpResult44 = lerp( lerpResult43 , ( _Color3 * tex2DNode11 ) , tex2DNode2.b);
			float4 appendResult129 = (float4(( 2.0 * lerpResult44 ).rgb , tex2DNode11.a));
			o.Albedo = ( appendResult129 * _Tint ).xyz;
			o.Alpha = ( tex2DNode11.a * _Tint.a );
		}

		ENDCG
	}
}