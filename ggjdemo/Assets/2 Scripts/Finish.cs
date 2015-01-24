using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision obj){
		
		if (obj.gameObject.tag == "Finish") {
			Debug.Log ("Level Complete!");
		}
	}

}
