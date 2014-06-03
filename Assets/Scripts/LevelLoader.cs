using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

	public GameObject player;
	public GameObject platform;
	public GameObject platformRemover;
	public GameObject countdownTimer;
	public GameObject buttons;
	public GameObject police;
	public GameObject chef;
	public GameObject food;
	public GameObject obstacle;

	[HideInInspector]public List<GameObject> listOfPlatforms = new List<GameObject>();
	[HideInInspector]public List<GameObject> listOfChefs = new List<GameObject>();
	
	public float platformStartX = 0.0f;
	public float platformStartY = 0.0f;

	public float newPlatformPositionX = 0.0f;
	public int amountOfPlatformsAtOneTime = 0;

	public float platformRemoverStartX = 0.0f;

	public int amountOfChefsAtOneTime = 0;

	void Awake()
	{
		Screen.orientation = ScreenOrientation.AutoRotation;

		InitObj(countdownTimer, countdownTimer.GetComponent<CountdownTimer>().countdownTimerX, countdownTimer.GetComponent<CountdownTimer>().countdownTimerY);
		InitObj(buttons, 0.0f, 0.0f);
		InitObj(player, player.GetComponent<Player>().playerX, player.GetComponent<Player>().playerY);
		InitObj(platformRemover, platformRemoverStartX, 0.0f);

		for(int i = 0; i < amountOfPlatformsAtOneTime; i++)
		{
			InitObjList(platform, listOfPlatforms, platformStartX + (platform.transform.localScale.x * i), platformStartY);
		}
		newPlatformPositionX = (float)(platformStartX + (platform.transform.localScale.x * amountOfPlatformsAtOneTime));

		InitObj(police, platformStartX + (platform.transform.localScale.x * amountOfPlatformsAtOneTime), platformStartY);

		for(int i = 0; i < amountOfChefsAtOneTime; i++)
		{
			InitObjList(chef, listOfChefs, chef.GetComponent<Chef>().chefX, chef.GetComponent<Chef>().chefY);
		}
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

	void InitObj(GameObject obj, float posX, float posY)
	{
		if(obj != null)
		{
			obj = SpawnObject(obj, new Vector2(posX, posY));
		}
	}

	void InitObjList(GameObject obj, List<GameObject> listOfObjs, float posX, float posY)
	{
		if(obj != null)
		{
			listOfObjs.Add(obj);
			listOfObjs[listOfObjs.Count - 1] = SpawnObject(listOfObjs[listOfObjs.Count - 1], new Vector2(posX, posY));
		}
	}
}
