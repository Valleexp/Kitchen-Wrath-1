using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// For XML Loading
using System.Text;
using System.Xml;
using System.IO;

public class RecipeLoader : MonoBehaviour {
	// Loads recipes from an XML file
	public TextAsset recipesXML;

	// Stores the list of all our recipes
	public List<Recipe> recipeList = new List<Recipe>();

	// Use this for initialization
	void Start () {
		LoadRecipesXML ();
	}

	// Load Recipes from an XML file
	void LoadRecipesXML()
	{
		Dictionary<string,string> obj;

		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml (recipesXML.text); // load the file.
		XmlNodeList allRecipes = xmlDoc.GetElementsByTagName("recipe"); // array of the recipes

		int i = 1;

		foreach (XmlNode recipeInfo in allRecipes)
		{
			Debug.Log("Number of Recipes: " + i);

			XmlNodeList recipeContent = recipeInfo.ChildNodes;
			obj = new Dictionary<string,string>();

			Recipe newRecipe = new Recipe();

			foreach(XmlNode recipeItems in recipeContent)
			{
				
				if(recipeItems.Name == "name")
				{
					newRecipe.recipeName = recipeItems.InnerText;
					Debug.Log("Name: " + newRecipe.recipeName);
				}

				if(recipeItems.Name == "description")
				{
					newRecipe.recipeDescription = recipeItems.InnerText;
					Debug.Log("Description: " + newRecipe.recipeDescription);
				}

				if(recipeItems.Name == "ingredient")
				{
					newRecipe.AddIngredient(recipeItems.InnerText); // put this in the dictionary.
					//Debug.Log("Ingredient: " + recipeItems.InnerText);
				}

			}

			recipeList.Add(newRecipe);
			

			i++;
		}
	}
}
