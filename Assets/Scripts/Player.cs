using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float playerX = 0.0f;
	public float playerY = 0.0f;
	public float playerJump = 0.0f;
	public float playerSpeed = 0.0f;
	public float playerMaxSpeed = 0.0f;
	public float playerAcceleration = 0.0f;

	[HideInInspector]public bool toggleJump = false;
	[HideInInspector]public bool toggleSlash = false;

	private bool isOnGround = false;

	[HideInInspector]public int slashChefCounter = 0;

	private GameObject highscore = null;
	private GameObject levelLoader = null;

	private Animator playerAnimator = null;

	// Use this for initialization
	void Start () {
		highscore = GameObject.FindGameObjectWithTag("Highscore");
		levelLoader = GameObject.Find("LevelLoader");

		playerAnimator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Time.deltaTime * playerSpeed;
		
		if(isOnGround)
		{
			Run();
		}
		else
		{
			InAir();
		}

		if(toggleJump && isOnGround)
		{
			Jump();
		}

		if(toggleSlash)
		{
			Slash();
			if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerJumping"))
			{
				JumpSlash();
			}
		}
		else
		{	
			UnSlash();
		}

		if(GetComponent<Timer>().TicksPastDelay() && playerSpeed < playerMaxSpeed)
		{
			Accelerate();
			GetComponent<Timer>().ResetTicks();
		}
	}

	private void Jump()
	{
		rigidbody2D.AddForce(new Vector2(0.0f, playerJump), ForceMode2D.Impulse);
	}

	private void InAir()
	{
		SetPlayerState(PLAYER_STATE.PLAYER_JUMPING);
	}

	private void JumpSlash()
	{
		SetPlayerState(PLAYER_STATE.PLAYER_JUMP_ATTACK);
	}

	private void Slash()
	{
		Physics2D.IgnoreLayerCollision((int)LAYER_VALUE.PLAYER, (int)LAYER_VALUE.CHEF, false);
		Physics2D.IgnoreLayerCollision((int)LAYER_VALUE.PLAYER, (int)LAYER_VALUE.FOOD, false);

		SetPlayerState(PLAYER_STATE.PLAYER_RUN_ATTACK);

		if(!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRunAttack"))
		{
			toggleSlash = false;
		}
	}

	private void UnSlash()
	{
		Physics2D.IgnoreLayerCollision((int)LAYER_VALUE.PLAYER, (int)LAYER_VALUE.CHEF, true);
		Physics2D.IgnoreLayerCollision((int)LAYER_VALUE.PLAYER, (int)LAYER_VALUE.FOOD, true);
	}

	private void Run()
	{
		SetPlayerState(PLAYER_STATE.PLAYER_RUNNING);
	}

	private void Accelerate()
	{
		playerSpeed += playerAcceleration;
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

//	void OnTriggerEnter2D(Collider2D obj)
//	{
//		switch(obj.gameObject.tag)
//		{
//		case "Chef":
//			slashChefCounter++;
//			break;
//		case "Chicken":
//			highscore.GetComponent<Score>().SetScoreProperties(4, 1);
//			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.CHICKEN);
//			break;
//		case "Egg":
//			highscore.GetComponent<Score>().SetScoreProperties(3, 1);
//			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.EGG);
//			break;
//		case "Potato":
//			highscore.GetComponent<Score>().SetScoreProperties(2, 1);
//			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.POTATO);
//			break;
//		case "Cabbage":
//			highscore.GetComponent<Score>().SetScoreProperties(1, 1);
//			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.CABBAGE);
//			break;
//		case "Carrot":
//			highscore.GetComponent<Score>().SetScoreProperties(1, 1);
//			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.CARROT);
//			break;
//		case "Pumpkin":
//			highscore.GetComponent<Score>().SetScoreProperties(1, 1);
//			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.PUMPKIN);
//			break;
//		case "Tomato":
//			highscore.GetComponent<Score>().SetScoreProperties(1, 1);
//			levelLoader.GetComponent<RecipeCheck>().AddIngredientToList(INGREDIENT.TOMATO);
//			break;
//		}
//	}

	private void SetPlayerState(PLAYER_STATE pState)
	{
		playerAnimator.SetInteger("PlayerState", (int)pState);
	}
}
	