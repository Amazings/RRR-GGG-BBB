using UnityEngine;
using System.Collections;

public class onClickBlue : MonoBehaviour {
	
	// Use this for initialization
	static Shader shader1 = Shader.Find("Diffuse");
	static Shader shader2 = Shader.Find("Particles/Additive (Soft)");

	//static Shader shader2  = Shader.Find("Particles/Multiply (Double)");
	void Start () {
		renderer.material.shader = shader2;
		collider.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetButtonDown("Red")) {
			Debug.Log("Red Platforms Activated!");
			renderer.material.shader = shader2;
			collider.enabled= false;
			
		}
		
		else if (Input.GetMouseButtonDown (1) || Input.GetButtonDown("Blue")) {
			Debug.Log("Blue Platforms Activated!");
			renderer.material.shader = shader1;
			collider.enabled = true;
		}
		
		
		else if (Input.GetMouseButtonDown (2) || Input.GetButtonDown("Green")) {
			Debug.Log("Green Platforms Activated!");
			renderer.material.shader = shader2;
			collider.enabled = false;
		}
	}
}
