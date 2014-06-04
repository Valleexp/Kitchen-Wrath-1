using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecipeCheck : MonoBehaviour {

	// the recipe list
	public List<Recipe> recipeList = new List<Recipe>();

	// the player's ingredient list in memory
	public List<INGREDIENT> playerIngredientList = new List<INGREDIENT>();

	// Use this for initialization
	void Start () {
		recipeList = GetComponent<RecipeLoader>().recipeList;
	}

	public string CheckRecipe()
	{
		//1. check against lists that have the highest amount of ingredients in them
		//2. At any point in time if we find that we have a match we break out of the loop and we return a recipe
		//3. if no such match was found with the highest count box, we remove one box and then try again until we left 3 boxes and then call it no recipe match

		for(int i = 0; i < recipeList.Count; i++)
		{
			bool isEqual = new HashSet<INGREDIENT>(recipeList[i].recipe).SetEquals(playerIngredientList);
			//bool isEqual = true;

//			for(int j = 0; j < playerIngredientList.Count; j++)
//			{
//				Debug.Log("Length of player ingredients: " + recipeList[i].recipe.Count);
//				if(recipeList[i].recipe[j] != playerIngredientList[j])
//				{
//					isEqual = false;
//					break;
//				}
//			}

			if(isEqual)
			{
				Debug.Log("We have a recipe match");
				return recipeList[i].recipeName;
			}
		}
		Debug.Log ("No match");
		return "no match";
	}

	public string AddIngredientToList(INGREDIENT ingredient)
	{
		if(playerIngredientList.Count < 3)
		{
			playerIngredientList.Add(ingredient);

			if(playerIngredientList.Count == 3)
			{
				//Debug.Log("Checking for recipe now");
				return CheckRecipe();
			}
		}
		else
		{
			playerIngredientList.Clear();
			playerIngredientList.Add(ingredient);
		}
		return "";
	}
}
