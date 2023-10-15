using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static RaceController singleton;
	public float timeOfCompletionRace => Time.time - timeOfStartingRace + amountMissedFlaqsInSeconds;
	
	private float timeOfStartingRace;
	private int amountMissedFlaqsInSeconds;

	private void Start()
	{
		singleton = this;
	}

	public void StartRace()
	{
		timeOfStartingRace = Time.time;
		RaceEvents.OnStartRace();
		Debug.Log("Race started!");
	}

	public void OnMissedFlaq()
	{
		amountMissedFlaqsInSeconds++;
		Debug.Log("Flaq missed!");
	}

	public void OnPassedFlaq()
	{
		Debug.Log("Flaq passed!");
	}

	public void FinishRace()
	{
		RaceEvents.OnFinishRace();
		Debug.Log("Race finished!");
		Debug.Log($"Amount of missed flaqs: {amountMissedFlaqsInSeconds}");
		Debug.Log($"Time of completion race: {timeOfCompletionRace}");
	}
}
