using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayUI : MonoBehaviour {

	public int ingredientBoxWidth = 50;
	public int ingredientBoxHeight = 50;
	public int ingredientBoxY = 50;
	public int ingredientBoxX = Screen.width - 200;

	public int amountOfBoxes = 3;

	public Texture defaultTexture;



	public List<Texture> ingredients = new List<Texture>();

	// the list of textures for the ingredients
	public Texture cabbageTexture;
	public Texture carrotTexture;
	public Texture potatoTexture;
	public Texture pumpkinTexture;
	public Texture tomatoTexture;
	

	// Put in 3 default no ingredient textures
	void Start () {
		for(int i = 0; amountOfBoxes < i; i ++)
		{
			ingredients.Add(defaultTexture);
		}
	}

	public void ChangeIngredientBox(List<INGREDIENT> playerIngredientList)
	{
		//Update the ingredients
		for(int i = 0; i < playerIngredientList.Count; i++)
		{
			switch(playerIngredientList[i])
			{
			case INGREDIENT.CABBAGE:
				ingredients[i] = cabbageTexture;
					break;

			case INGREDIENT.CARROT:
				ingredients[i] = carrotTexture;
				break;

			case INGREDIENT.POTATO:
				ingredients[i] = potatoTexture;
				break;

			case INGREDIENT.PUMPKIN:
				ingredients[i] = pumpkinTexture;
				break;

			case INGREDIENT.TOMATO:
				ingredients[i] = tomatoTexture;
				break;
			default:
				Debug.Log("We don't have the texture for that food you just obtained yet!");
				break;
			}
		}
	}

	void OnGUI()
	{
		//Displays Ingredients Boxes that contains what you have recently slashed to the top right of game screen
		if (!ingredients[0]) {
			Debug.LogError("Assign a Texture to ingredients[0] in the inspector.");
		}
		else
		{
			GUI.DrawTexture(new Rect(ingredientBoxX + 10, ingredientBoxY, ingredientBoxWidth, ingredientBoxHeight), ingredients[0], ScaleMode.StretchToFill, true, 10.0F);
		}

		if (!ingredients[1]) {
			Debug.LogError("Assign a Texture to ingredients[1] in the inspector.");
		}
		else
		{
			GUI.DrawTexture(new Rect(ingredientBoxX + 70, ingredientBoxY, ingredientBoxWidth, ingredientBoxHeight), ingredients[1], ScaleMode.StretchToFill, true, 10.0F);
		}

		if (!ingredients[2]) {
			Debug.LogError("Assign a Texture to ingredients[2] in the inspector.");
		}
		else
		{
			GUI.DrawTexture(new Rect(ingredientBoxX + 130, ingredientBoxY, ingredientBoxWidth, ingredientBoxHeight), ingredients[2], ScaleMode.StretchToFill, true, 10.0F);
		}
	}

}
