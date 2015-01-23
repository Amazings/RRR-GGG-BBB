using UnityEngine;
using System.Collections;

public class onClickBlue : MonoBehaviour {

	// Use this for initialization
	static Shader shader1 = Shader.Find("Diffuse");
	static Shader shader2  = Shader.Find("Particles/Additive");
	//static Shader shader2  = Shader.Find("Particles/Multiply (Double)");
	void Start () {
		renderer.material.shader = shader2;
		collider.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			renderer.material.shader = shader2;
			collider.enabled= false;

				}
			


		if (Input.GetMouseButtonDown (1)) {
				
			renderer.material.shader = shader1;
			collider.enabled = true;
			}



		if (Input.GetMouseButtonDown (2)) {
			renderer.material.shader = shader2;
			collider.enabled=false;
				}
	}
}
