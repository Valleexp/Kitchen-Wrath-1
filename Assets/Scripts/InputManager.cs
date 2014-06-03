using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private GameObject player = null;
	private GameObject jumpButton = null;
	private GameObject slashButton = null;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		jumpButton = GameObject.FindGameObjectWithTag("JumpButton");
		slashButton = GameObject.FindGameObjectWithTag("SlashButton");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			player.GetComponent<Player>().toggleJump = true;
		}
		else
		{
			player.GetComponent<Player>().toggleJump = false;
		}

//		if(Input.touchCount > 0)
//		{
//			if(Input.GetTouch(0).phase == TouchPhase.Began)
//			{
//				player.GetComponent<Player>().toggleJump = true;
//			}
//			else
//			{
//				player.GetComponent<Player>().toggleJump = false;
//			}
//		}

		foreach(Touch touch in Input.touches)
		{
			switch(touch.phase)
			{
			case TouchPhase.Began:
				break;
			}
		}
	}
}
