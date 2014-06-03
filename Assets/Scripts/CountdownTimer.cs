using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

	public float countdownTimerX = 0.0f;
	public float countdownTimerY = 0.0f;

	private string countdownHours = "";
	private string countdownMinutes = "";
	private string countdownSeconds = "";

	private string countdownDisplay = "";

	void Awake()
	{
		TextDisplay();
		GetComponent<TextMesh>().transform.position = new Vector3(countdownTimerX, countdownTimerY);
		GetComponent<Timer>().StartTime();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		TextDisplay();
		GetComponent<TextMesh>().transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GetComponent<TextMesh>().transform.position.y);
	}

	private void TextDisplay()
	{
		if(HoursLessThanTen())
		{
			countdownHours = "0" + GetComponent<Timer>().hours.ToString();
		}
		else
		{
			countdownHours = GetComponent<Timer>().hours.ToString();
		}

		if(MinutesLessThanTen())
		{
			countdownMinutes = "0" + GetComponent<Timer>().minutes.ToString();
		}
		else
		{
			countdownMinutes = GetComponent<Timer>().minutes.ToString();
		}

		if(SecondsLessThanTen())
		{
			countdownSeconds = "0" + GetComponent<Timer>().seconds.ToString();
		}
		else
		{
			countdownSeconds = GetComponent<Timer>().seconds.ToString();
		}

		countdownDisplay = countdownHours + ":" + countdownMinutes + ":" + countdownSeconds;
		GetComponent<TextMesh>().text = countdownDisplay;
	}

	private bool HoursLessThanTen()
	{
		if(GetComponent<Timer>().hours < 10)
		{
			return true;
		}
		return false;
	}

	private bool MinutesLessThanTen()
	{
		if(GetComponent<Timer>().minutes < 10)
		{
			return true;
		}
		return false;
	}

	private bool SecondsLessThanTen()
	{
		if(GetComponent<Timer>().seconds < 10)
		{
			return true;
		}
		return false;
	}
}
