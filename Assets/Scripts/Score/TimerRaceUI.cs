using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerRaceUI : MonoBehaviour
{
	[SerializeField] private Text timerOfRaceText;

	private bool isRaceStarted ;
	private int timeOfCompletionRace => (int)RaceController.singleton.timeOfCompletionRace;

	private void OnEnable()
	{
		RaceEvents.OnRaceLoaded += ClearTimer;
		RaceEvents.OnRaceStarted += () => { isRaceStarted = true; };
		RaceEvents.OnRaceFinished += () => { isRaceStarted = false; };
	}

	private void OnDisable()
	{
		RaceEvents.OnRaceLoaded -= ClearTimer;
		RaceEvents.OnRaceStarted -= () => { isRaceStarted = true; };
		RaceEvents.OnRaceFinished -= () => { isRaceStarted = false; };
	}

	private void Update()
	{
		if (isRaceStarted)
		{
			TimeSpan time = TimeSpan.FromSeconds(timeOfCompletionRace);
			if (time.Seconds < 10)
			{
				timerOfRaceText.text = time.Minutes.ToString() + ":0" + time.Seconds.ToString();
			}
			else
			{
				timerOfRaceText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
			}
		}
	}

	private void ClearTimer()
	{
		timerOfRaceText.text = "0:00";
	}
}
