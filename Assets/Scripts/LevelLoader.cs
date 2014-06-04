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

		InitObj(countdownTimer, countdownTimer.GetComponent<CountdownTimer>().countdownTimerX, countdownTimer.GetComponent<CountdownTimer>().countdownTimerY);
		InitObj(highscore, highscore.GetComponent<Highscore>().highscoreX, highscore.GetComponent<Highscore>().highscoreY);
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
			InitObjList(chef, listOfChefs, chef.GetComponent<Chef>().chefX + (i * Random.Range(2, 10)), chef.GetComponent<Chef>().chefY);
		}

		for(int i = 0; i < amountOfFoodsAtOneTime; i++)
		{
//			InitObjList(food, listOfFoods, (i * Random.Range(2, 10)), platformStartY + ((i + 1) * Random.Range(2, 5)));
			InitFoodListRandom((i * Random.Range(2, 10)), platformStartY + ((i + 1) * Random.Range(2, 5)), 
			                   (int)INGREDIENT.CHICKEN, (int)INGREDIENT.TOMATO);
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

	void InitFoodListRandom(float posX, float posY, int min, int max)
	{
		int foodValue = RandomsGenerator.RandomInt(min, max);

		switch(foodValue)
		{
		case (int)INGREDIENT.CHICKEN:
			InitObjList(chicken, listOfFoods, posX, posY);
			break;
		case (int)INGREDIENT.EGG:
			InitObjList(egg, listOfFoods, posX, posY);
			break;
		case (int)INGREDIENT.POTATO:
			InitObjList(potato, listOfFoods, posX, posY);
			break;
		case (int)INGREDIENT.CABBAGE:
			InitObjList(cabbage, listOfFoods, posX, posY);
			break;
		case (int)INGREDIENT.CARROT:
			InitObjList(carrot, listOfFoods, posX, posY);
			break;
		case (int)INGREDIENT.PUMPKIN:
			InitObjList(pumpkin, listOfFoods, posX, posY);
			break;
		case (int)INGREDIENT.TOMATO:
			InitObjList(tomato, listOfFoods, posX, posY);
			break;
		}
	}
}
