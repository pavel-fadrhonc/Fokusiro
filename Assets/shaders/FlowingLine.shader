// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "LD/Flowing Line" {
Properties {
    _MainColor ("Color Tint", COLOR) = (1.0, 1.0, 1.0)
	//_horizonColor ("Horizon color", COLOR)  = ( .172 , .463 , .435 , 0)
	_WaveScale ("Wave scale", Range (0.02,0.15)) = .07
	_FadeOutline ("Fade Outline", Range(0.1, 1.0)) = .9
//	[HideInInspector] _BoundsTR ("Bounds", Vector) = (0.0, 0.0, 0.0, 0.0)
//	[HideInInspector] _BoundsTL ("Bounds", Vector) = (0.0, 0.0, 0.0, 0.0)
//	[HideInInspector] _BoundsBR ("Bounds", Vector) = (0.0, 0.0, 0.0, 0.0)
//	[HideInInspector] _BoundsBL ("Bounds", Vector) = (0.0, 0.0, 0.0, 0.0)
	[NoScaleOffset] _ColorControl ("Reflective color (RGB) fresnel (A) ", 2D) = "" { }
	[NoScaleOffset] _BumpMap ("Waves Normalmap ", 2D) = "" { }
	WaveSpeed ("Wave speed (map1 x,y; map2 x,y)", Vector) = (19,9,-16,-7)
	}

CGINCLUDE

#include "UnityCG.cginc"

//uniform float4 _horizonColor;

uniform float4 WaveSpeed;
uniform float _WaveScale;
uniform float4 _WaveOffset;
uniform float4 _MainColor;
uniform float _FadeOutline;

//uniform float4 _BoundsTR;
//uniform float4 _BoundsTL;
//uniform float4 _BoundsBR;
//uniform float4 _BoundsBL;

struct appdata {
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	float2 uv : TEXCOORD0;
};

struct v2f {
	float4 pos : SV_POSITION;
	float2 uv : TEXCOORD3;
	float2 bumpuv[2] : TEXCOORD0;
	float3 viewDir : TEXCOORD2;
	UNITY_FOG_COORDS(3)
};

v2f vert(appdata v)
{
	v2f o;
	float4 s;

	o.pos = UnityObjectToClipPos(v.vertex);
	o.uv = v.uv;

	// scroll bump waves
	float4 temp;
	float4 wpos = mul (unity_ObjectToWorld, v.vertex);
	temp.xyzw = wpos.xyxy * _WaveScale + _WaveOffset;
	o.bumpuv[0] = temp.xy * float2(.4, .45);
	o.bumpuv[1] = temp.wz;

	// object space view direction
	o.viewDir.xzy = normalize( WorldSpaceViewDir(v.vertex) );

	UNITY_TRANSFER_FOG(o,o.pos);
	return o;
}

ENDCG


Subshader {
	Tags { "RenderType"="Transparent" }
	Pass {
	Blend SrcAlpha OneMinusSrcAlpha

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_fog

sampler2D _BumpMap;
sampler2D _ColorControl;

half4 frag( v2f i ) : COLOR
{
	half3 bump1 = UnpackNormal(tex2D( _BumpMap, i.bumpuv[0] )).rgb;
	half3 bump2 = UnpackNormal(tex2D( _BumpMap, i.bumpuv[1] )).rgb;
	half3 bump = (bump1 + bump2) * 0.5;
	
	half fresnel = dot( i.viewDir, bump );
	half4 water = tex2D( _ColorControl, float2(fresnel,fresnel) );
	
	half4 col;
	col.rgb = lerp( water.rgb, _MainColor.rgb, water.a );
	col.a = _MainColor.a;	
	
	float min_ = 1.0;
	if (i.uv.x < (1.0-_FadeOutline))
	{
	    min_ = min(min_, i.uv.x);
	}
	if (i.uv.y < (1.0-_FadeOutline))
	{
	    min_ = min(min_, i.uv.y);
	}
	if (i.uv.x > (_FadeOutline))
	{
	    min_ = min(min_, 1.0 - i.uv.x);
	}
	if (i.uv.y > (_FadeOutline))
	{
	    min_ = min(min_, 1.0 - i.uv.y);
	}
	col.a *= clamp(min_ / (1.0 - _FadeOutline), 0.0, 1.0);
	
	


	//UNITY_APPLY_FOG(i.fogCoord, col);
	return col;
}
ENDCG
	}
}

}
