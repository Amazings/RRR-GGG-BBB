using UnityEngine;
using System.Collections;

public class BackToCheckpoint : MonoBehaviour {

	public Vector3 lastGoodPosition = new Vector3( 0,0,0);
	public string nextScene = "";
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
		else if (collision.gameObject.tag == "Finish")
		{
			Debug.Log ("asdD");
			if( nextScene != "")
			//Application.LoadLevel(nextScene);
			AutoFade.LoadLevel(nextScene, 0.5f, 0.5f, Color.black);
		}
	}
}
