using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public int hours = 0;
	public int minutes = 0;
	public int seconds = 0;

	private float ticks = 0.0f;
	private bool countdown = false;

	void Awake()
	{
		TimerCheck();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		CountdownTimer();
	}

	public void StartTime()
	{
		countdown = true;
	}

	private void CountdownTimer()
	{
		if(countdown)
		{
			if(ticks >= 1.0f)
			{
				if(seconds > 0)
				{
					seconds--;
				}

				if(seconds <= 0 && minutes > 0)
				{
					minutes--;
					seconds = 59;
				}
				
				if(minutes <= 0 && hours > 1)
				{
					hours--;
					minutes = 59;
				}
				
				if(hours <= 0)
				{
					hours = 0;
				}
				
				if(hours <= 0 && minutes <= 0 && seconds <= 0)
				{
					countdown = false;
				}
				ticks = 0.0f;
			}
			else
			{
				ticks += Time.deltaTime;
			}
		}
	}

	private void TimerCheck()
	{
		if(seconds > 60)
		{
			seconds -= 60;
			minutes += 1;
		}
		
		if(minutes > 60)
		{
			minutes -= 60;
			hours += 1;
		}
		
		if(hours > 24)
		{
			hours = 24;
		}
	}
}
