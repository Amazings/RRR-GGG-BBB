using UnityEngine;
using System.Collections;

public class trampoline : MonoBehaviour {

	
	bool willBounce = false;
	float bounceHeight = 10;
	public Transform Player;
	public Vector3 velocity;

	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (willBounce) {


			Player.rigidbody.velocity = velocity;
			Debug.Log (Player.rigidbody.velocity);
						willBounce = false;
				} 

	}
	
	void OnCollisionEnter (Collision other)
	{
		Debug.Log ("collided na");
		if (other.gameObject.tag == "Player") {
						Debug.Log ("collide");
						willBounce = true;
			gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, 
			                                              gameObject.transform.localScale.y/2
			                                              , gameObject.transform.localScale.z);
				}
		
	}

	void OnCollisionExit (Collision other)
	{
		Debug.Log ("collided na");
		if (other.gameObject.tag == "Player") {
			Debug.Log ("collide");
			willBounce = false;
			gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, 
			                                              gameObject.transform.localScale.y*2
			                                              , gameObject.transform.localScale.z);
		}
		
	}


	
}