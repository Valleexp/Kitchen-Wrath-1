using UnityEngine;
using System.Collections;

public class GameOverCheck : MonoBehaviour {

	//Pointer to the player for drop through gap detection
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("LevelLoader").GetComponent<LevelLoader>().player;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("Player's position: " + player.transform.position);


		// when the player hits -10 on the y we assume the player has died and we gameover
		if(player.transform.position.y < -10.0f)
		{
			Application.LoadLevel("Gameover");
		}
	}
}
