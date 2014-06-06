using UnityEngine;
using System.Collections;

public class GameOverCheck : MonoBehaviour {

	public float minPos = 0.0f;

	//Pointer to the player for drop through gap detection
	private GameObject levelLoader;
	private GameObject player;
	private GameObject countdownTimer;

	void Awake()
	{
		levelLoader = GameObject.Find ("LevelLoader");
		player = levelLoader.GetComponent<LevelLoader>().player;
		countdownTimer = levelLoader.GetComponent<LevelLoader>().countdownTimer;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

//		Debug.Log ("Player's position: " + player.transform.position);
		GameoverByPos();
		GameoverByTime();
	}

	private void GameoverByPos()
	{
		// when the player hits -10 on the y we assume the player has died and we gameover
		if(player.transform.position.y < -10.0f)
		{
			Application.LoadLevel("Gameover");
		}
	}

	private void GameoverByTime()
	{
		if(!countdownTimer.GetComponent<Timer>().CountdownTimerStarted())
		{
			Application.LoadLevel("Gameover");
		}
	}
}
