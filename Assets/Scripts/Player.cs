using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float playerX = 0.0f;
	public float playerY = 0.0f;
	public float playerJump = 0.0f;
	public float playerSpeed = 0.0f;

	public bool toggleJump = false;
	private bool isOnGround = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Time.deltaTime * playerSpeed;
		if(toggleJump && isOnGround)
		{
			Jump();
		}
	}

	void Jump()
	{
		rigidbody2D.AddForce(new Vector2(0.0f, playerJump));
	}

	void OnCollisionEnter2D(Collision2D platform)
	{
		if(platform.gameObject.tag == "Platform")
		{
			isOnGround = true;
		}
	}

	void OnCollisionExit2D(Collision2D platform)
	{
		if(platform.gameObject.tag == "Platform")
		{
			isOnGround = false;
		}
	}
}
	