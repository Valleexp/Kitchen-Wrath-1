using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float playerX = 0.0f;
	public float playerY = 0.0f;
	public float playerJump = 0.0f;
	public float playerSpeed = 0.0f;

	[HideInInspector]public bool toggleJump = false;
	[HideInInspector]public bool toggleSlash = false;

	private bool isOnGround = false;

	[HideInInspector]public int slashChefCounter = 0;

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

		if(toggleSlash)
		{
			Slash();
		}
		else
		{
			UnSlash();
		}
	}

	void Jump()
	{
		rigidbody2D.AddForce(new Vector2(0.0f, playerJump));
	}

	void Slash()
	{
		renderer.material.color = Color.red;
	}

	void UnSlash()
	{
		renderer.material.color = Color.white;
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		switch(obj.gameObject.tag)
		{
		case "Platform":
			isOnGround = true;
			break;
		case "Chef":
			slashChefCounter++;
			break;
		}
	}

	void OnCollisionExit2D(Collision2D obj)
	{
		switch(obj.gameObject.tag)
		{
		case "Platform":
			isOnGround = false;
			break;
		}
	}
}
	