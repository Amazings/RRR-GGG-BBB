using UnityEngine;
using System.Collections;

public class BackToCheckpoint : MonoBehaviour {

	public Vector3 lastGoodPosition = new Vector3( 0,0,0);
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("collision");
		if (collision.gameObject.tag == "Checkpoint")
		{

			lastGoodPosition = transform.position;
		}
		else if (collision.gameObject.tag == "Respawn")
		{
			Debug.Log ("asdD");
			transform.position = lastGoodPosition;
		}
	}
}
