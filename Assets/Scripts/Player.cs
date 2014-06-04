using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float playerX = 0.0f;
	public float playerY = 0.0f;
	public float playerJump = 0.0f;
	public float playerSpeed = 0.0f;
	public float playerAcceleration = 0.0f;

	[HideInInspector]public bool toggleJump = false;
	[HideInInspector]public bool toggleSlash = false;

	private bool isOnGround = false;

	[HideInInspector]public int slashChefCounter = 0;

	private GameObject highscore = null;
	private GameObject levelLoader = null;

	// Use this for initialization
	void Start () {
		highscore = GameObject.FindGameObjectWithTag("Highscore");
		levelLoader = GameObject.Find("LevelLoader");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Time.deltaTime * playerSpeed;

		if(toggleJump && isOnGround)
		{
			Jump();
		}
			
		if(toggleSlash)
		{
			Physics2D.IgnoreLayerCollision((int)LayerData.LAYERVALUE.PLAYER, (int)LayerData.LAYERVALUE.CHEF, false);
			Physics2D.IgnoreLayerCollision((int)LayerData.LAYERVALUE.PLAYER, (int)LayerData.LAYERVALUE.FOOD, false);
			Slash();
		}
		else
		{
			Physics2D.IgnoreLayerCollision((int)LayerData.LAYERVALUE.PLAYER, (int)LayerData.LAYERVALUE.CHEF, true);
			Physics2D.IgnoreLayerCollision((int)LayerData.LAYERVALUE.PLAYER, (int)LayerData.LAYERVALUE.FOOD, true);
			UnSlash();
		}

		if(GetComponent<Timer>().TicksPastDelay())
		{
			Accelerate();
			GetComponent<Timer>().ResetTicks();
		}
	}

	void Jump()
	{
		rigidbody2D.AddForce(new Vector2(0.0f, playerJump), ForceMode2D.Impulse);
	}

	void Slash()
	{
		GetComponentInChildren<SpriteRenderer>().color = Color.red;
	}

	void UnSlash()
	{
		GetComponentInChildren<SpriteRenderer>().color = Color.white;
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		switch(obj.gameObject.tag)
		{
		case "Platform":
			isOnGround = true;
			break;
		case "Chef":
			slashChefCounter++;
			break;
//		case "Food":
//			highscore.GetComponent<Score>().SetScoreProperties(10, 1);
//			break;
		case "Chicken":
			highscore.GetComponent<Score>().SetScoreProperties(4, 1);
			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.CHICKEN);
			break;
		case "Egg":
			highscore.GetComponent<Score>().SetScoreProperties(3, 1);
			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.EGG);
			break;
		case "Potato":
			highscore.GetComponent<Score>().SetScoreProperties(2, 1);
			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.POTATO);
			break;
		case "Cabbage":
			highscore.GetComponent<Score>().SetScoreProperties(1, 1);
			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.CABBAGE);
			break;
		case "Carrot":
			highscore.GetComponent<Score>().SetScoreProperties(1, 1);
			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.CARROT);
			break;
		case "Pumpkin":
			highscore.GetComponent<Score>().SetScoreProperties(1, 1);
			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.PUMPKIN);
			break;
		case "Tomato":
			highscore.GetComponent<Score>().SetScoreProperties(1, 1);
			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.TOMATO);
			break;
		}
	}

	void OnCollisionExit2D(Collision2D obj)
	{
		switch(obj.gameObject.tag)
		{
		case "Platform":
			isOnGround = false;
			break;
		}
	}

	private void Accelerate()
	{
		playerSpeed += playerAcceleration;
	}
}
	