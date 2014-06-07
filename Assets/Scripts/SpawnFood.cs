using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFood : MonoBehaviour {

	public List<GameObject> listOfFood = new List<GameObject>();

	// Use this for initialization
	void Start () {
		// Spawn food now
		// Random type of food on platform
		int randomAmountOfFood = 0;
		
		if(gameObject.tag == "Platform")
		{
			// Depends on the how long the platform is we spawn a certain amount of food onto the plaform
			float platformExtentsX = collider2D.bounds.extents.x;
			float platformExtentsY = collider2D.bounds.extents.y;

			if(transform.localScale.x == 2.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFood = RandomsGenerator.RandomInt (0, 1);
			}
			else if(transform.localScale.x == 4.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFood = RandomsGenerator.RandomInt (0, 2);
			}
			else if(transform.localScale.x == 8.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFood = RandomsGenerator.RandomInt (1, 3);
			}
			else if(transform.localScale.x == 16.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFood = RandomsGenerator.RandomInt (0, 4);
			}

			// Spawn our foods
			for(int i = 0; i < randomAmountOfFood; i++)
			{
				int typeOfFood = RandomsGenerator.RandomInt (0, listOfFood.Count - 1);

				float platformEdgeOffset = 0.5f;

				float randomFoodX = RandomsGenerator.RandomFloat (gameObject.transform.position.x - platformExtentsX + platformEdgeOffset
				                                                  , gameObject.transform.position.x + platformExtentsX - platformEdgeOffset);
				
				GameObject specificFood = listOfFood[typeOfFood] as GameObject;
				
				specificFood = SpawnFoodType(ref specificFood, randomFoodX, 10000.0f);

				//float foodExtentsX = listOfFood[typeOfFood].collider2D.bounds.extents.x;
				float foodExtentsY = specificFood.collider2D.bounds.extents.y;

				specificFood.transform.position = new Vector2(randomFoodX, gameObject.transform.position.y + gameObject.collider2D.bounds.extents.y + foodExtentsY);
			}
		}
		else if(gameObject.tag == "DoublePlatform")
		{
			foreach (Transform child in transform)
			{
				if (child.tag == "Platform")
				{
					Debug.Log("Double Platform instantiating");
					float platformExtentsX = child.gameObject.collider2D.bounds.extents.x;
					float platformExtentsY = child.gameObject.collider2D.bounds.extents.y;

					randomAmountOfFood = RandomsGenerator.RandomInt (1, 4);

					// Spawn our foods
					for(int i = 0; i < randomAmountOfFood; i++)
					{
						int typeOfFood = RandomsGenerator.RandomInt (0, listOfFood.Count - 1);
						
						float platformEdgeOffset = 0.5f;
						
						float randomFoodX = RandomsGenerator.RandomFloat (child.gameObject.transform.position.x - platformExtentsX + platformEdgeOffset
						                                                  , child.gameObject.transform.position.x + platformExtentsX - platformEdgeOffset);
						
						GameObject specificFood = listOfFood[typeOfFood] as GameObject;
						
						specificFood = SpawnFoodType(ref specificFood, randomFoodX, 10000.0f);
						
						float foodExtentsY = specificFood.collider2D.bounds.extents.y;
						
						specificFood.transform.position = new Vector2(randomFoodX, child.gameObject.transform.position.y + child.gameObject.collider2D.bounds.extents.y + foodExtentsY);
					}
				}
			}
			
		}
	}
	
	
	
	private GameObject SpawnFoodType(ref GameObject food, float posX, float posY)
	{
		return Instantiate(food, new Vector2(posX, posY), Quaternion.identity)as GameObject;
	}
}
