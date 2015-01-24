using UnityEngine;
using System.Collections;

public class CoinCollector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision obj){

		if (obj.gameObject.tag == "Collect") {
			Destroy (obj.gameObject);
			Debug.Log ("Coin Collected");
		}

	
	
	}
}
