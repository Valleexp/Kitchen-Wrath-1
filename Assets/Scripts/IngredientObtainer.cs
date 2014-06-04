using UnityEngine;
using System.Collections;

public class IngredientObtainer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.CHICKEN);
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.EGG);
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.POTATO);
		}

		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.CABBAGE);
		}

	}
}
