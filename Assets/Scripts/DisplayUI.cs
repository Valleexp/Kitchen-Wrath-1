using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayUI : MonoBehaviour {

	public int ingredientBoxWidth = 50;
	public int ingredientBoxHeight = 50;
	public int ingredientBoxY = 50;
	public int ingredientBoxX = Screen.width - 200;

	
	public Texture firstIngredient;
	public Texture secondIngredient;
	public Texture thirdIngredient;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI()
	{
		//Displays Ingredients Boxes that contains what you have recently slashed to the top right of game screen
		if (!firstIngredient) {
			Debug.LogError("Assign a Texture to firstIngredient in the inspector.");
		}
		else
		{
			GUI.DrawTexture(new Rect(ingredientBoxX + 10, ingredientBoxY, ingredientBoxWidth, ingredientBoxHeight), firstIngredient, ScaleMode.StretchToFill, true, 10.0F);
		}

		if (!secondIngredient) {
			Debug.LogError("Assign a Texture to secondIngredient in the inspector.");
		}
		else
		{
			GUI.DrawTexture(new Rect(ingredientBoxX + 70, ingredientBoxY, ingredientBoxWidth, ingredientBoxHeight), secondIngredient, ScaleMode.StretchToFill, true, 10.0F);
		}

		if (!thirdIngredient) {
			Debug.LogError("Assign a Texture to thirdIngredient in the inspector.");
		}
		else
		{
			GUI.DrawTexture(new Rect(ingredientBoxX + 130, ingredientBoxY, ingredientBoxWidth, ingredientBoxHeight), thirdIngredient, ScaleMode.StretchToFill, true, 10.0F);
		}
	}

}
