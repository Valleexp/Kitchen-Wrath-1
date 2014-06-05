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
//			bool isEqual = new HashSet<INGREDIENT>(recipeList[i].recipe).SetEquals(playerIngredientList);
			Debug.Log("Amount of times we have tried checking!");
			bool isEqual = true;

			for(int j = 0; j < playerIngredientList.Count; j++)
			{
				if(recipeList[i].recipe[j] != playerIngredientList[j])
				{
					isEqual = false;
					break;
				}
			}

			//Debug.Log("Compared to recipe: " + recipeList[i].recipe[0] + recipeList[i].recipe[1] + recipeList[i].recipe[2]);
			//Debug.Log("Player Ingredient list:  " + playerIngredientList[0] + playerIngredientList[1] + playerIngredientList[2]);
			Debug.Log("Is Equal: " + isEqual);
			if(isEqual)
			{
				Debug.Log("We have a recipe match");

				GetComponent<DisplayUI>().completedRecipe = recipeList[i].recipeName;
				return recipeList[i].recipeName;
			}
		}

		GetComponent<DisplayUI>().completedRecipe = "no match";
		
		Debug.Log ("No match");
		return "no match";
	}

	public string AddIngredientToList(INGREDIENT ingredient)
	{
		if(playerIngredientList.Count < 3)
		{
			if(playerIngredientList.Count == 0)
			{
				GetComponent<DisplayUI>().ResetIngredientBoxTextures();
			}


			playerIngredientList.Add(ingredient);

			GetComponent<DisplayUI>().ChangeIngredientBox(playerIngredientList);

			if(playerIngredientList.Count == 3)
			{
				//Debug.Log("Checking for recipe now");
				return CheckRecipe();
			}
		}
		else
		{
			playerIngredientList.Clear();
			GetComponent<DisplayUI>().ResetIngredientBoxTextures();
			
			playerIngredientList.Add(ingredient);
			GetComponent<DisplayUI>().ChangeIngredientBox(playerIngredientList);
			
		}
		return "";
	}
}
