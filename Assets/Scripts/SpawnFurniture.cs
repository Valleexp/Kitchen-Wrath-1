using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFurniture : MonoBehaviour {

	public List<GameObject> listOfFurniture = new List<GameObject>();

	// Use this for initialization
	void Start () {
		// Spawn food now
		// Random type of food on platform
		int randomAmountOfFurniture = 0;

		if(gameObject.tag == "Platform")
		{
			float platformExtentsX = collider2D.bounds.extents.x;
			float platformExtentsY = collider2D.bounds.extents.y;

			// Depends on the how long the platform is we spawn a certain amount of food onto the plaform
			if(transform.localScale.x == 2.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFurniture = RandomsGenerator.RandomInt (0, 1);
			}
			else if(transform.localScale.x == 4.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFurniture = RandomsGenerator.RandomInt (0, 1);
			}
			else if(transform.localScale.x == 8.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFurniture = RandomsGenerator.RandomInt (0, 2);
			}
			else if(transform.localScale.x == 16.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFurniture = RandomsGenerator.RandomInt (0, 3);
			}

			// Spawn our furniture
			for(int i = 0; i < randomAmountOfFurniture; i++)
			{
				int typeOfFurniture = RandomsGenerator.RandomInt (0, listOfFurniture.Count - 1);

				float platformEdgeOffset = 0.5f;
				
				float randomFurnitureX = RandomsGenerator.RandomFloat (gameObject.transform.position.x - platformExtentsX + platformEdgeOffset
				                                                       , gameObject.transform.position.x + platformExtentsX - platformEdgeOffset);
				
				GameObject specificFurniture = listOfFurniture[typeOfFurniture] as GameObject;
				
				specificFurniture = SpawnFoodType(ref specificFurniture, randomFurnitureX, 10000.0f);

				//float furnitureExtentsX = specificFurniture.collider2D.bounds.extents.x;
				float furnitureExtentsY = specificFurniture.collider2D.bounds.extents.y;

				specificFurniture.transform.position = new Vector2(randomFurnitureX, gameObject.transform.position.y + gameObject.collider2D.bounds.extents.y + furnitureExtentsY);
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
					
					randomAmountOfFurniture = RandomsGenerator.RandomInt (1, 4);
					
					// Spawn our foods
					for(int i = 0; i < randomAmountOfFurniture; i++)
					{
						int typeOfFood = RandomsGenerator.RandomInt (0, listOfFurniture.Count - 1);
						
						float platformEdgeOffset = 0.5f;
						
						float randomFurnitureX = RandomsGenerator.RandomFloat (child.gameObject.transform.position.x - platformExtentsX + platformEdgeOffset
						                                                  , child.gameObject.transform.position.x + platformExtentsX - platformEdgeOffset);
						
						GameObject specificFurniture = listOfFurniture[typeOfFood] as GameObject;
						
						specificFurniture = SpawnFoodType(ref specificFurniture, randomFurnitureX, 10000.0f);
						
						float furnitureExtentsY = specificFurniture.collider2D.bounds.extents.y;
						
						specificFurniture.transform.position = new Vector2(randomFurnitureX, child.gameObject.transform.position.y + child.gameObject.collider2D.bounds.extents.y + furnitureExtentsY);
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
