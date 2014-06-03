using UnityEngine;
using System.Collections;

public class Chef : MonoBehaviour {

	public float chefX = 0.0f;
	public float chefY = 0.0f;
	public float chefSpeed = 0.0f;
	public float chefRecoil = 0.0f;

	[HideInInspector]public bool toggleRecoil = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * Time.deltaTime * chefSpeed;

		if(toggleRecoil)
		{
			Recoil();
		}
	}

	void Recoil()
	{
		rigidbody2D.AddForce(new Vector2(Vector3.right.x * chefRecoil, Vector3.up.y * chefRecoil));
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		switch(obj.gameObject.tag)
		{
		case "Player":
			toggleRecoil = true;
			break;
		}
	}
	
	void OnCollisionExit2D(Collision2D obj)
	{
		switch(obj.gameObject.tag)
		{
		case "Player":
			toggleRecoil = false;
			break;
		}
	}
}
