using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public float aspeed = 2;
	public float jumpAmount = 10;
	public float gravity = .1f;
	public float friction = .01f;
	
	private Vector3 _velocity;
	private Vector3 _pos;
	private CharacterController _charController;
	
	void Start () 
	{
		_velocity = new Vector3();
		_pos = gameObject.transform.position;
		_charController = GetComponentInChildren<CharacterController>();
	}
	
	void Update ()
	{
		float hInput = Input.GetAxis("Horizontal");
		_velocity.x += (hInput * aspeed);
		
		_velocity.x *= friction;
		
		Debug.Log(_velocity);
		
		Debug.Log(_charController.isGrounded);
		
		if (!_charController.isGrounded)
		{
			_velocity.y -= gravity;
		}
		
		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log ("jump");	
			_velocity.y = jumpAmount;
		}
		
		_pos += (_velocity * Time.deltaTime);
		
		_charController.transform.position = _pos;
	}
	/*
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Platform")
		{
			
		}
	}
	*/
}
