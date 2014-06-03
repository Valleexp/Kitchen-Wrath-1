using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

	public GameObject player;
	public GameObject platform;
	public GameObject platformRemover;
	public GameObject countdownTimer;
	public GameObject buttons;

	[HideInInspector]public List<GameObject> listOfPlatforms = new List<GameObject>();
	
	public float platformStartX = 0.0f;
	public float platformStartY = 0.0f;

	public float newPlatformPositionX = 0.0f;
	public int amountOfPlatformsAtOneTime = 0;

	public float platformRemoverStartX = 0.0f;

	void Awake()
	{
		Screen.orientation = ScreenOrientation.AutoRotation;

		InitCountdownTimer(countdownTimer.GetComponent<CountdownTimer>().countdownTimerX, countdownTimer.GetComponent<CountdownTimer>().countdownTimerY);

		InitButtons(0.0f, 0.0f);

		InitPlayer(player.GetComponent<Player>().playerX, player.GetComponent<Player>().playerY);

		InitPlatformRemover(platformRemoverStartX, 0.0f);

		for(int i = 0; i < amountOfPlatformsAtOneTime; i++)
		{
			InitPlatform(platformStartX + (platform.transform.localScale.x * i), platformStartY);
		}
		newPlatformPositionX = (float)(platformStartX + (platform.transform.localScale.x * amountOfPlatformsAtOneTime));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	GameObject SpawnObject(GameObject gObj, Vector2 position)
	{
		return (GameObject)Instantiate((Object)(gObj), new Vector3(position.x, position.y, 0.0f), Quaternion.identity);  
	}

	void InitPlayer(float posX, float posY)
	{
		if(player != null)
		{
			player = SpawnObject(player, new Vector2(posX, posY));
		}
	}

	void InitPlatform(float posX, float posY)
	{
		if(platform != null)
		{
			listOfPlatforms.Add(platform);
			listOfPlatforms[listOfPlatforms.Count - 1] = SpawnObject(listOfPlatforms[listOfPlatforms.Count - 1], new Vector2(posX, posY));
		}
	}

	void InitPlatformRemover(float posX, float posY)
	{
		if(platformRemover != null)
		{
			platformRemover = SpawnObject(platformRemover, new Vector2(posX, posY));
		}
	}

	void InitCountdownTimer(float posX, float posY)
	{
		if(countdownTimer != null)
		{
			countdownTimer = SpawnObject(countdownTimer, new Vector2(posX, posY));
		}
	}

	void InitButtons(float posX, float posY)
	{
		if(buttons != null)
		{
			buttons = SpawnObject(buttons, new Vector2(posX, posY));
		}
	}
}
