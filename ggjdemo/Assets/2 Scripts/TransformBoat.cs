using UnityEngine;
using System.Collections;

public class TransformBoat : MonoBehaviour {

	public Vector3 lastGoodPosition = new Vector3(0,0,0);
	public Vector3 test = new Vector3 (95, 1, 0);
	public string boat_ind  = "N";
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Colliding");
		
		if (collision.gameObject.tag == "Player")
		{
			//	AutoFade.LoadLevel("1-2", 0.5f, 0.5f, Color.black);
			//	lastGoodPosition = transform.position;
			lastGoodPosition = test;
			boat_ind  = "Y";

		}
	}

	public void ResetBoat (string respawn){
		if (respawn == "Y" && boat_ind == "Y") {
			transform.position = lastGoodPosition;
				}
	}
	 
}
