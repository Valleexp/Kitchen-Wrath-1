using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

	public GameObject[] typeOfPlatforms;

	public GameObject startingPlatform;

	public int amountOfPlatforms;

	public float lastPlatformEdgeX = 0.0f;
	public float lastPlatformEdgeY = -3.0f;

	// gap values inbetween platforms
	public float randomGapXMin = 0.0f;
	public float randomGapXMax = 5.0f;

	public float randomGapYMin = 0.0f;
	public float randomGapYMax = 5.0f;

	public float highestY = 2.3f;
	public float lowestY = -4.5f;

	List<GameObject> platforms = new List<GameObject>();

	// Use this for initialization
	void Start () {
		// Initialise platforms

		// We always spawn the first platform for the player to be on to always be something that is fixed
		platforms.Add(Instantiate(startingPlatform, new Vector2(lastPlatformEdgeX, lastPlatformEdgeY), Quaternion.identity) as GameObject);

		// position at right edge of previous platform
		lastPlatformEdgeX += (startingPlatform.transform.localScale.x / 2);

		

		// lowest -4.5 highest 2.3
		
		for(int i = 0; i < amountOfPlatforms - 1; i++)
		{
			SpawnPlatform();
		}
	}


	public void SpawnPlatform()
	{
		// randomise a platform
		int platformType = Random.Range(0, typeOfPlatforms.Length);
		
		// half/width + gap + half/width to obtain the position
		
		// calculate gap 
		lastPlatformEdgeX += Random.Range(randomGapXMin, randomGapXMax);
		
		
		// randomise up if the next platform is going to be higher or lower
		if(Random.value > 0.5)
		{
			float tempHold = Random.Range(randomGapYMin, randomGapYMax);
//			Debug.Log("Val: "+tempHold);
			lastPlatformEdgeY += tempHold;
//			Debug.Log("lastPlatformEdgeY: "+lastPlatformEdgeY);
			if(lastPlatformEdgeY > highestY)
			{
				lastPlatformEdgeY = highestY;
			}
		}
		else
		{
			lastPlatformEdgeY = Random.Range(lowestY, lastPlatformEdgeY);
			if(lastPlatformEdgeY < lowestY)
			{
				lastPlatformEdgeY = lowestY;
			}
		}
		
		// position now past halfway left at the center of the new randomized platform
		lastPlatformEdgeX += (typeOfPlatforms[platformType].transform.localScale.x / 2);
		
		// Spawn a platform
		platforms.Add(Instantiate(typeOfPlatforms[platformType], new Vector2(lastPlatformEdgeX, lastPlatformEdgeY), Quaternion.identity) as GameObject);
		lastPlatformEdgeX += (typeOfPlatforms[platformType].transform.localScale.x / 2);
	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
