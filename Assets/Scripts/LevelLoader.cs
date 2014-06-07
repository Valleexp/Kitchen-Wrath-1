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
	public GameObject chicken;
	public GameObject egg;
	public GameObject potato;
	public GameObject cabbage;
	public GameObject carrot;
	public GameObject pumpkin;
	public GameObject tomato;
	public GameObject obstacle;
	public GameObject highscore;
	public GameObject sky;
	public GameObject background;
	public GameObject midground;
	public GameObject foreground;
	
	[HideInInspector]public List<GameObject> listOfPlatforms = new List<GameObject>();
	[HideInInspector]public List<GameObject> listOfChefs = new List<GameObject>();
	[HideInInspector]public List<GameObject> listOfFoods = new List<GameObject>();
	
	public float platformStartX = 0.0f;
	public float platformStartY = 0.0f;
	
	public float newPlatformPositionX = 0.0f;
	public int amountOfPlatformsAtOneTime = 0;
	
	public float platformRemoverStartX = 0.0f;
	
	public int amountOfChefsAtOneTime = 0;
	
	public int amountOfFoodsAtOneTime = 0;

	void Awake()
	{
		Screen.orientation = ScreenOrientation.AutoRotation;

		InitObj(ref sky, 0.0f, 0.0f, 10.0f);
		InitObj(ref background, 0.0f, 0.0f, 8.0f);
		InitObj(ref midground, 0.0f, -3.0f, 5.0f);
		InitObj(ref foreground, 0.0f, -3.5f, 3.0f);

		InitObj(ref countdownTimer, countdownTimer.GetComponent<CountdownTimer>().countdownTimerX, 
		        countdownTimer.GetComponent<CountdownTimer>().countdownTimerY, 0.0f);

		InitObj(ref highscore, highscore.GetComponent<Highscore>().highscoreX, highscore.GetComponent<Highscore>().highscoreY, 0.0f);
		InitObj(ref buttons, 0.0f, 0.0f, 0.0f);
		InitObj(ref player, player.GetComponent<Player>().playerX, player.GetComponent<Player>().playerY, 0.0f);
		InitObj(ref platformRemover, platformRemoverStartX, 0.0f, 0.0f);

		for(int i = 0; i < amountOfPlatformsAtOneTime; i++)
		{
			//InitObjList(platform, listOfPlatforms, platformStartX + (platform.transform.localScale.x * i), platformStartY);
		}
		newPlatformPositionX = (float)(platformStartX + (platform.transform.localScale.x * amountOfPlatformsAtOneTime));

//		InitObj(ref police, platformStartX + (platform.transform.localScale.x * amountOfPlatformsAtOneTime), platformStartY);

		for(int i = 0; i < amountOfChefsAtOneTime; i++)
		{
//			InitObjList(chef, ref listOfChefs, chef.GetComponent<Chef>().chefX + (i * Random.Range(2, 10)), chef.GetComponent<Chef>().chefY);
		}

		for(int i = 0; i < amountOfFoodsAtOneTime; i++)
		{
//			InitObjList(food, listOfFoods, (i * Random.Range(2, 10)), platformStartY + ((i + 1) * Random.Range(2, 5)));
			InitFoodListRandom((i * Random.Range(2, 10)), platformStartY + ((i + 1) * Random.Range(2, 5)), 0.0f, 
			                   (int)INGREDIENT.POTATO, (int)INGREDIENT.TOMATO);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	GameObject SpawnObject(GameObject gObj, Vector3 position)
	{
		return (GameObject)Instantiate((Object)(gObj), new Vector3(position.x, position.y, position.z), Quaternion.identity);  
	}

	void InitObj(GameObject obj, float posX, float posY, float posZ)
	{
		if(obj != null)
		{
			obj = SpawnObject(obj, new Vector3(posX, posY, posZ));
		}
	}

	void InitObj(ref GameObject obj, float posX, float posY, float posZ)
	{
		if(obj != null)
		{
			obj = SpawnObject(obj, new Vector3(posX, posY, posZ));
		}
	}

	void InitObjList(GameObject obj, List<GameObject> listOfObjs, float posX, float posY, float posZ)
	{
		if(obj != null)
		{
			listOfObjs.Add(obj);
			listOfObjs[listOfObjs.Count - 1] = SpawnObject(listOfObjs[listOfObjs.Count - 1], new Vector3(posX, posY, posZ));
		}
	}

	void InitObjList(GameObject obj, ref List<GameObject> listOfObjs, float posX, float posY, float posZ)
	{
		if(obj != null)
		{
			listOfObjs.Add(obj);
			listOfObjs[listOfObjs.Count - 1] = SpawnObject(listOfObjs[listOfObjs.Count - 1], new Vector3(posX, posY, posZ));
		}
	}

	void InitFoodListRandom(float posX, float posY, float posZ, int min, int max)
	{
		int foodValue = RandomsGenerator.RandomInt(min, max);

		switch(foodValue)
		{
		case (int)INGREDIENT.CHICKEN:
			InitObjList(chicken, ref listOfFoods, posX, posY, posZ);
			break;
		case (int)INGREDIENT.EGG:
			InitObjList(egg, ref listOfFoods, posX, posY, posZ);
			break;
		case (int)INGREDIENT.POTATO:
			InitObjList(potato, ref listOfFoods, posX, posY, posZ);
			break;
		case (int)INGREDIENT.CABBAGE:
			InitObjList(cabbage, ref listOfFoods, posX, posY, posZ);
			break;
		case (int)INGREDIENT.CARROT:
			InitObjList(carrot, ref listOfFoods, posX, posY, posZ);
			break;
		case (int)INGREDIENT.PUMPKIN:
			InitObjList(pumpkin, ref listOfFoods, posX, posY, posZ);
			break;
		case (int)INGREDIENT.TOMATO:
			InitObjList(tomato, ref listOfFoods, posX, posY, posZ);
			break;
		}
	}
}
