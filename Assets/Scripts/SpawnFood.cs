using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnFood : MonoBehaviour {

	public List<GameObject> listOfFood = new List<GameObject>();

	// Use this for initialization
	void Start () {
		// Spawn food now
		// Random type of food on platform

		if(gameObject.tag == "Platform")
		{
			float platformExtentsX = collider2D.bounds.extents.x;
			float platformExtentsY = collider2D.bounds.extents.y;

			int randomAmountOfFood = 0;

			// Depends on the how long the platform is we spawn a certain amount of food onto the plaform
			//float platformSizeX = collider2D.bounds.extents.x;
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
				randomAmountOfFood = RandomsGenerator.RandomInt (0, 3);
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
				
				float foodExtentsX = listOfFood[typeOfFood].collider2D.bounds.extents.x;
				float foodExtentsY = listOfFood[typeOfFood].collider2D.bounds.extents.y;
				
				//Debug.Log(foodExtentsX);
				
				float randomFoodX = RandomsGenerator.RandomFloat (gameObject.transform.position.x - platformExtentsX
				                                                  , gameObject.transform.position.x + platformExtentsX);
				
				float foodY = gameObject.transform.position.y + gameObject.collider2D.bounds.extents.y + foodExtentsY;
				
				GameObject specificFood = listOfFood[RandomsGenerator.RandomInt (0, listOfFood.Count - 1)] as GameObject;
				
				specificFood = SpawnFoodType(ref specificFood, randomFoodX, foodY);

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
