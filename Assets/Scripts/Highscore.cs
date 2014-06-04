using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {

	public float highscoreX = 0.0f;
	public float highscoreY = 0.0f;

	private string highscoreDisplay = "0";

	private GameObject mainCamera = null;

	void Awake()
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		TextDisplay();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TextDisplay();
	}
	
	private void TextDisplay()
	{
		highscoreDisplay = "SCORE: " + GetComponent<Score>().highscore;
		GetComponent<GUIText>().text = highscoreDisplay;
	}
}
