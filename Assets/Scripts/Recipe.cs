using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum INGREDIENT
{
	CHICKEN = 0,
	EGG,
	POTATO,
	CABBAGE,
	CARROT,
	PUMPKIN,
	TOMATO
};

public class Recipe{

	public string recipeName = "";
	public List<INGREDIENT> recipe = new List<INGREDIENT>();
	public string recipeDescription = "";

	// we might have to put in the effect here

	public void AddIngredient(string toConvert)
	{
		toConvert = toConvert.ToUpper ();

		//Debug.Log ("Ingredient: " + (int)System.Enum.Parse(typeof(INGREDIENT), toConvert));
		recipe.Add ((INGREDIENT)System.Enum.Parse(typeof(INGREDIENT), toConvert));
	}

}
