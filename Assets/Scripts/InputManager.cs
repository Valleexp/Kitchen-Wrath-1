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
		//keyboard test
		if(Input.GetKeyDown(KeyCode.Space))
		{
			player.GetComponent<Player>().toggleJump = true;
		}
		else
		{
			player.GetComponent<Player>().toggleJump = false;
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			player.GetComponent<Player>().toggleSlash = true;
		}
		else
		{
			player.GetComponent<Player>().toggleSlash = false;
		}

		if(Input.touchCount > 0)
		{


			if(jumpButton.guiTexture.HitTest(Input.GetTouch(0).position) && Input.touches[0].phase == TouchPhase.Began)
			{
				player.GetComponent<Player>().toggleJump = true;
			}
			else
			{
				player.GetComponent<Player>().toggleJump = false;
			}

			if(slashButton.guiTexture.HitTest(Input.GetTouch(0).position) && Input.touches[0].phase == TouchPhase.Began)
			{
				player.GetComponent<Player>().toggleSlash = true;
			}
			else
			{
				player.GetComponent<Player>().toggleSlash = false;
			}
		}

//		foreach(Touch touch in Input.touches)
//		{
//			switch(touch.phase)
//			{
//			case TouchPhase.Began:
//				break;
//			case TouchPhase.Canceled:
//				break;
//			case TouchPhase.Ended:
//				break;
//			case TouchPhase.Moved:
//				break;
//			case TouchPhase.Stationary:
//				break;
//			case iPhoneTouchPhase.Began:
//				break;
//			case iPhoneTouchPhase.Canceled:
//				break;
//			case iPhoneTouchPhase.Ended:
//				break;
//			case iPhoneTouchPhase.Moved:
//				break;
//			case iPhoneTouchPhase.Stationary:
//				break;
//			}
//		}
	}
}
