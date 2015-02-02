using UnityEngine;
using System.Collections;

public class onClickRed : MonoBehaviour {
	static Shader shader1 = Shader.Find("Diffuse");
	static Shader shader2  = Shader.Find("Particles/Additive (Soft)");
	//static Shader shader2  = Shader.Find("Particles/Multiply (Double)");
	// Use this for initialization
	void Start () {
		renderer.material.shader = shader2;
		collider.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) || Input.GetButtonDown("Red")) {
				renderer.material.shader = shader1;			
				collider.enabled= true;
		}
		
		if (Input.GetMouseButtonDown (1) || Input.GetButtonDown("Blue")) {
			renderer.material.shader = shader2;
			collider.enabled = false;
		}
		
		if (Input.GetMouseButtonDown (2) || Input.GetButtonDown("Green")) {
			renderer.material.shader = shader2;
			collider.enabled = false;
		}
	}
}
