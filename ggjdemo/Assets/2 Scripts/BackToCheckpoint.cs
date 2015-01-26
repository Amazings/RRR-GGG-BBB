using UnityEngine;
using System.Collections;

public class BackToCheckpoint : MonoBehaviour {

	public Vector3 lastGoodPosition = new Vector3( 0,0,0);
	public string nextScene = "";

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Colliding");

		if (collision.gameObject.tag == "Respawn" && Application.loadedLevelName == "1-2")
		{
		//	AutoFade.LoadLevel("1-2", 0.5f, 0.5f, Color.black);
		//	lastGoodPosition = transform.position;
			transform.position = lastGoodPosition;
			GameObject go = GameObject.Find("Boat");
			TransformBoat other = (TransformBoat) go.GetComponent(typeof(TransformBoat));
			other.ResetBoat("Y");

		}

		//if (collision.gameObject.tag == "Checkpoint" && collision.gameObject.name != "Checkpoint")
		//{
		//	Debug.Log (collision.gameObject.name);
		//	lastGoodPosition = transform.position;
		//}
		else if (collision.gameObject.tag == "Checkpoint" && collision.gameObject.name == "Checkpoint")
		{
			Destroy(collision.gameObject);
			Debug.Log ("Player Checkpoint!");
			lastGoodPosition = transform.position;
		}

		else if (collision.gameObject.tag == "Respawn" && Application.loadedLevelName != "1-2")
		{
			Debug.Log ("Player is out of bounds!");
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
