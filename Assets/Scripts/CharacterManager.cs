using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour {

	private GameObject levelLoader = null;
	private GameObject player = null;
	private GameObject police = null;
	private List<GameObject> listOfChefs = new List<GameObject>();

	public int minSlashChefCounter = 0;
	private int updateSlashCount = 0;

	// Use this for initialization
	void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		CheckChefCounter();
	}

	void Init()
	{
		levelLoader = GameObject.Find("LevelLoader");
		player = GameObject.FindGameObjectWithTag("Player");
		police = GameObject.FindGameObjectWithTag("Police");

		listOfChefs = levelLoader.GetComponent<LevelLoader>().listOfChefs;
	}

	void CheckChefCounter()
	{
		if(player.GetComponent<Player>().slashChefCounter == minSlashChefCounter)
		{
			police.renderer.enabled = true;
			updateSlashCount++;
		}
		else if(player.GetComponent<Player>().slashChefCounter - updateSlashCount > 0)
		{
			
		}
	}
}
