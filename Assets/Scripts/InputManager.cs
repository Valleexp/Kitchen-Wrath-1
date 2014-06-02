using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private GameObject Player = null;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Player.GetComponent<Player>().toggleJump = true;
		}
		else
		{
			Player.GetComponent<Player>().toggleJump = false;
		}

		if(Input.touchCount > 0)
		{
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Player.GetComponent<Player>().toggleJump = true;
			}
			else
			{
				Player.GetComponent<Player>().toggleJump = false;
			}
		}
	}
}
