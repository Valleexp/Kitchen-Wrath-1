using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	[HideInInspector]public int score = 0;
	[HideInInspector]public int scoreMultiplyer = 0;
	[HideInInspector]public int highscore = 0;
	
	[HideInInspector]public bool addScore = false;

	private int tempHighscore = 0;

	private float ticks = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(addScore)
		{
			AddScore();
		}
		else
		{
			tempHighscore = highscore;
		}
	}

	private void AddScore()
	{
		if(GetComponent<Timer>().TicksPastDelay())
		{
			highscore += 1;
			GetComponent<Timer>().ResetTicks();
		}

		if(highscore >= tempHighscore + (score * scoreMultiplyer))
		{
			addScore = false;
		}
	}

	public void SetScoreProperties(int newScore, int newScoreMultiplyer)
	{
		score = newScore;
		scoreMultiplyer = newScoreMultiplyer;
		addScore = true;
	}
}
