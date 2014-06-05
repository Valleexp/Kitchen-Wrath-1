using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjManager : MonoBehaviour {

	private GameObject levelLoader = null;
	private GameObject player = null;
	private GameObject police = null;

	public int minSlashChefCounter = 0;
	private int updateSlashCount = 0;

	// Use this for initialization
	void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreLayerCollision((int)LAYER_VALUE.POLICE, (int)LAYER_VALUE.CHEF, true);
		Physics2D.IgnoreLayerCollision((int)LAYER_VALUE.POLICE, (int)LAYER_VALUE.FOOD, true);
		Physics2D.IgnoreLayerCollision((int)LAYER_VALUE.CHEF, (int)LAYER_VALUE.FOOD, true);
	
		CheckChefCounter();
	}

	void Init()
	{
		levelLoader = GameObject.Find("LevelLoader");
		player = GameObject.FindGameObjectWithTag("Player");
		police = GameObject.FindGameObjectWithTag("Police");
	}

	private void CheckChefCounter()
	{
		if(player != null && police != null)
		{
			if(player.GetComponent<Player>().slashChefCounter == minSlashChefCounter)
			{
				police.renderer.enabled = true;
				updateSlashCount = minSlashChefCounter;
			}
			else if(player.GetComponent<Player>().slashChefCounter - updateSlashCount > 0)
			{
				if(police.GetComponent<Police>().differenceX > 0)
				{
					police.GetComponent<Police>().differenceX -= 2.0f;
				}
				updateSlashCount = player.GetComponent<Player>().slashChefCounter;
			}
		}
	}
}
