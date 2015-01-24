using UnityEngine;
using System.Collections;

public class showInstruction : MonoBehaviour {
	public Transform player;
	public Vector3 desiredPosition;
	public int xLimit;
	// Use this for initialization
	private bool shown = false;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x >= xLimit && shown == false) {
			transform.position = desiredPosition;
			shown = true;
				} else {

				}
	}


}
