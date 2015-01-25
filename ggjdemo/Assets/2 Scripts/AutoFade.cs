using UnityEngine;
using System;
using System.Collections;
     
public class AutoFade : MonoBehaviour {
    private static AutoFade m_Instance = null;
    private Material m_Material = null;
    private bool m_Fading = false;

    private static AutoFade Instance {
    	get {
    		if (m_Instance == null) {
   				 m_Instance = (new GameObject("AutoFade")).AddComponent<AutoFade>();
    		}
    		return m_Instance;
    	}
    }

    public static bool Fading {
    	get { return Instance.m_Fading; }
    }
     
    private void Awake() {
    	DontDestroyOnLoad(this);
    	m_Instance = this;
    	m_Material = new Material("Shader \"Plane/No zTest\" { SubShader { Pass { Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off Fog { Mode Off } BindChannels { Bind \"Color\",color } } } }");
    }
     
    private void DrawQuad(Color aColor,float aAlpha) {
	    aColor.a = aAlpha;
	    m_Material.SetPass(0);
	    GL.PushMatrix();
	    GL.LoadOrtho();
	    GL.Begin(GL.QUADS);
		GL.Color(aColor);
	    GL.Vertex3(0, 0, -1);
	    GL.Vertex3(0, 1, -1);
	    GL.Vertex3(1, 1, -1);
	    GL.Vertex3(1, 0, -1);
	    GL.End();
	    GL.PopMatrix();
    }
     
    private IEnumerator Fade(float aFadeOutTime, float aFadeInTime, Color aColor, Action action) {
    	float t = 0.0f;
    	while (t < 1.0f) {
    		yield return new WaitForEndOfFrame();
    		t = Mathf.Clamp01(t + RealTime.realDeltaTime / aFadeOutTime);
    		DrawQuad(aColor,t);
    	}

		t = 1.0f;

		action();

		while (t>0.0f) {
		    yield return new WaitForEndOfFrame();
			t = Mathf.Clamp01(t - RealTime.realDeltaTime / aFadeInTime);
		    DrawQuad(aColor,t);
		}
		m_Fading = false;
	}

	private void StartFade(float aFadeOutTime, float aFadeInTime, Color aColor, Action action) {
		    m_Fading = true;
		    StartCoroutine(Fade(aFadeOutTime, aFadeInTime, aColor, action));
	}

	public static void FadeInOut(float aFadeOutTime, float aFadeInTime, Color aColor, Action action) {
		if (Fading) {
			return;
		}

		Instance.StartFade(aFadeOutTime, aFadeInTime, aColor, action);
	}
     
    public static void LoadLevel(string aLevelName,float aFadeOutTime, float aFadeInTime, Color aColor) {
	    if (Fading) {
			return;
		}
	
		Action action = () => { Application.LoadLevel(aLevelName); };

		Instance.StartFade(aFadeOutTime, aFadeInTime, aColor, action);
    }

    public static void LoadLevel(int aLevelIndex,float aFadeOutTime, float aFadeInTime, Color aColor) {
	    if (Fading) {
			return;
		}

		Action action = () => { Application.LoadLevel(aLevelIndex); };

		Instance.StartFade(aFadeOutTime, aFadeInTime, aColor, action);
	}

	void OnApplicationQuit () {
		Destroy(this);
	}
}