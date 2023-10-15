using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedRacesScore : MonoBehaviour
{
	private static bool isInitialized;

	private const string nameOfScoreCompletedRacesInMemory = "Score of completed races";
	private int currentAmountOfCompletedRaces = 0;

	private void OnEnable()
	{
		RaceEvents.OnRaceFinished += OnFinishedRace;
	}

	private void OnDisable()
	{
		RaceEvents.OnRaceFinished -= OnFinishedRace;
	}

	private void Start()
	{
		if(isInitialized)
		{
			Destroy(gameObject);
			return;
		}

		isInitialized = true;
		currentAmountOfCompletedRaces = PlayerPrefs.GetInt(nameOfScoreCompletedRacesInMemory, 0);
		DontDestroyOnLoad(gameObject);
	}

	private void OnFinishedRace()
	{
		currentAmountOfCompletedRaces++;
		Debug.Log("Total amount of completed races: " + currentAmountOfCompletedRaces);
	}

	private void OnApplicationQuit()
	{
		PlayerPrefs.SetInt(nameOfScoreCompletedRacesInMemory, currentAmountOfCompletedRaces);
	}
}
