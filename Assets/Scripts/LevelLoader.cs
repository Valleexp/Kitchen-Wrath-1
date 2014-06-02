using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

	public GameObject player;
	public GameObject platform;
	public GameObject platformRemover;

	[HideInInspector]public List<GameObject> listOfPlatforms = new List<GameObject>();
	
	public float platformStartX = 0.0f;
	public float platformStartY = 0.0f;

	public float newPlatformPositionX = 0.0f;
	public int amountOfPlatformsAtOneTime = 0;
	public float platformLength = 0.0f;

	public float platformRemoverStartX = 0.0f;

	public float cameraDistance = 0.0f;

	void Awake()
	{
		Screen.orientation = ScreenOrientation.AutoRotation;

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
		// stick the camera to the player
		Camera.main.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3 (0.0f, 0.0f, cameraDistance);
	}

	void SpawnObject(GameObject gObj, Vector2 position)
	{
		Instantiate((Object)(gObj), new Vector3(position.x, position.y, 0.0f), Quaternion.identity);  
	}

	void InitPlayer(float posX, float posY)
	{
		if(player != null)
		{
			player.GetComponent<Player>().playerX = posX;
			player.GetComponent<Player>().playerY = posY;

			SpawnObject(player, new Vector2(posX, posY));
		}
	}

	void InitPlatform(float posX, float posY)
	{
		if(platform != null)
		{
			listOfPlatforms.Add(platform);

			listOfPlatforms[listOfPlatforms.Count - 1].GetComponent<Platform>().platformX = posX;
			listOfPlatforms[listOfPlatforms.Count - 1].GetComponent<Platform>().platformY = posY;

			SpawnObject(listOfPlatforms[listOfPlatforms.Count - 1], new Vector2(posX, posY));
		}
	}

	void InitPlatformRemover(float posX, float posY)
	{
		if(platformRemover != null)
		{
			SpawnObject(platformRemover, new Vector2(posX, posY));
		}
	}
}
