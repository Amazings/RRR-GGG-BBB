// VacuumShaders 2014
// https://www.facebook.com/VacuumShaders

Shader "VacuumShaders/Fragmentum/Demo/Skeletons DX11"
{
	Properties 
	{     
		[HideInInspector]
		_Color ("", Color) = (1,1,1,1)
		[HideInInspector]
		_MainTex ("", 2D) = "white" {}	   
		   

  
		[HideInInspector]
		V_FR_FragTexture("", 2D) = "white"{}	
		[HideInInspector]
		V_FR_FragTexturePower("", Range(1, 10)) = 1
		              
		            
		[HideInInspector]   
		V_FR_Fragmentum("", Range(0, 1)) = 0.5
		[HideInInspector]
		V_FR_DisplaceAmount("", float) = 1	 
		[HideInInspector]     
		V_FR_RotateSpeed("", float) = 1    
		[HideInInspector]
		V_FR_DisplaceDirectionObjectPosition("", vector) = (0, 1, 0, 0)
		[HideInInspector]  
		V_FR_FragmentsScale("", float) = 1  
		     
		[HideInInspector]   
		V_FR_DistanceToActivator("", float) = 0
		   
 		[HideInInspector]   
		V_FR_FragTexture("", 2D) = "white"{}		
		[HideInInspector] 
		V_FR_FragTexturePower("", Range(1, 10)) = 1
		     		      
		[HideInInspector] 
		V_FR_RandomizeFragmentum("", float) = 0   
		[HideInInspector]
	 	V_FR_RandomizeFragmentsScale("", float) = 0 
		[HideInInspector]
		V_FR_RandomizeDistanceToActivator("", float) = 0 
		[HideInInspector] 
		V_FR_RandomizeInitialRotation("", float) = 0
		[HideInInspector] 
		V_FR_RandomizeRotationSpeed("", float) = 0
		[HideInInspector]
		V_FR_RandomizeRotationTimeOffset("", float) = 0
		[HideInInspector]   
		V_FR_RandomizeDisplaceDirection("", Range(0, 1)) = 0
		[HideInInspector]   
		V_FR_RandomizeDisplaceAmount("", float) = 0  	
		
	}   
	                                                 
	SubShader                       
	{     
		Tags { "Queue"="Geometry" "RenderType"="Opaque" "FragmentumTag"="Fragmentum/DX11/Unity Surface Shader/Diffuse" }
		LOD 300     
				                                               
//DO NOT MODIFY !!! Cull		
Cull Off                                  
		                                  
		CGPROGRAM   
		#pragma target 5.0  
		#pragma only_renderers d3d11 
		#pragma surface surf Lambert vertex:vert addshadow fullforwardshadows
		   
		#pragma multi_compile V_FR_EDITOR_ON V_FR_EDITOR_OFF  

//DO NOT MODIFY !!! Defines
#define V_FR_ACTIVATOR_SPHERE
#define V_FR_ROTATE_PARENT_ORIGIN


		#define V_FR_SURFACE   
		#define V_FR_FRAGMENT_TEXTURE_ON

		#include "../cginc/FragmentumCG_DX11.cginc"  
		  

		ENDCG         
	}      

	FallBack "Diffuse"
	CustomEditor "FragmentumMaterial_Editor"

}
                       