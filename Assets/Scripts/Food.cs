using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public float foodRecoil = 0.0f;
	
	public float destroyDelay = 0.0f;
	
	[HideInInspector]public bool toggleRecoil = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(toggleRecoil)
		{
			Recoil();
		}
		Physics2D.IgnoreLayerCollision((int)LAYER_VALUE.FOOD, (int)LAYER_VALUE.FOOD, true);
	}
	
	void Recoil()
	{
		rigidbody2D.AddForce(new Vector2(Vector3.right.x * foodRecoil, Vector3.up.y * foodRecoil), ForceMode2D.Impulse);
	}
	
	void OnCollisionEnter2D(Collision2D obj)
	{
		switch(obj.gameObject.tag)
		{
		case "Player":
			toggleRecoil = true;
			Destroy(this.gameObject, destroyDelay);
			collider2D.isTrigger = true;
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
