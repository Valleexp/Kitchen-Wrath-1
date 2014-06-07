using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFurniture : MonoBehaviour {

	public List<GameObject> listOfFurniture = new List<GameObject>();

	// Use this for initialization
	void Start () {
		// Spawn food now
		// Random type of food on platform

		if(gameObject.tag == "Platform")
		{
			float platformExtentsX = collider2D.bounds.extents.x;
			float platformExtentsY = collider2D.bounds.extents.y;

			int randomAmountOfFurniture = 0;

			// Depends on the how long the platform is we spawn a certain amount of food onto the plaform
			//float platformSizeX = collider2D.bounds.extents.x;
			if(transform.localScale.x == 2.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFurniture = RandomsGenerator.RandomInt (0, 1);
			}
			else if(transform.localScale.x == 4.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFurniture = RandomsGenerator.RandomInt (0, 2);
			}
			else if(transform.localScale.x == 8.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFurniture = RandomsGenerator.RandomInt (0, 3);
			}
			else if(transform.localScale.x == 16.0f)
			{
				//determine amount of food for this plaform
				randomAmountOfFurniture = RandomsGenerator.RandomInt (0, 4);
			}

			// Spawn our foods
			for(int i = 0; i < randomAmountOfFurniture; i++)
			{
				int typeOfFurniture = RandomsGenerator.RandomInt (0, listOfFurniture.Count - 1);
				
				float furnitureExtentsX = listOfFurniture[typeOfFurniture].collider2D.bounds.extents.x;
				float furnitureExtentsY = listOfFurniture[typeOfFurniture].collider2D.bounds.extents.y;
				
//				Debug.Log(furnitureExtentsX);
				
				float randomFurnitureX = RandomsGenerator.RandomFloat (gameObject.transform.position.x - platformExtentsX
				                                                  , gameObject.transform.position.x + platformExtentsX);
				
				float foodY = gameObject.transform.position.y + gameObject.collider2D.bounds.extents.y + furnitureExtentsY;
				
				GameObject specificFood = listOfFurniture[RandomsGenerator.RandomInt (0, listOfFurniture.Count - 1)] as GameObject;
				
				specificFood = SpawnFoodType(ref specificFood, randomFurnitureX, foodY);

			}
		}
		else if(gameObject.tag == "DoublePlatform")
		{

		}
	}



	private GameObject SpawnFoodType(ref GameObject food, float posX, float posY)
	{
		return Instantiate(food, new Vector2(posX, posY), Quaternion.identity)as GameObject;
	}
}
