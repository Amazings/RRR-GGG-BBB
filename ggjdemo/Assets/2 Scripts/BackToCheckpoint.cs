using UnityEngine;
using System.Collections;

public class BackToCheckpoint : MonoBehaviour {

	public Vector3 lastGoodPosition = new Vector3( 0,0,0);
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Block")
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
