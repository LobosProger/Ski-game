using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
	private const string defaultNameOfTimeRecordRace = "Record time";
	private const int maxAmountOfBestRecords = 5;

	private string nameOfRetrievingRecordOfRace => defaultNameOfTimeRecordRace + RaceLevelManager.singleton.nameOfCurrentLevel;

	private void Start()
	{
		RaceEvents.OnRaceFinished += OnFinishedRace;
	}

	private void OnDisable()
	{
		RaceEvents.OnRaceFinished -= OnFinishedRace;
	}

	private void OnFinishedRace()
	{
		List<float> bestRecords = GetListOfTopRecords();
		LeaderboardUI.singleton.ShowRecordsOnUI(bestRecords);
		SetBestRecordsIntoMemory(bestRecords);
	} 

	private List<float> GetListOfTopRecords()
	{
		List<float> recordsList = new List<float>();
		for(int i=0; i<=maxAmountOfBestRecords; i++)
		{
			string keyForAccessRecord = nameOfRetrievingRecordOfRace + i.ToString();
			float record = PlayerPrefs.GetFloat(keyForAccessRecord, -1);

			if (record == -1)
				continue;

			recordsList.Add(record);
		}

		float achievedRecordOnRace = RaceController.singleton.timeOfCompletionRace;
		recordsList.Add(achievedRecordOnRace);
		recordsList.Sort();

		if (recordsList.Count > maxAmountOfBestRecords)
		{
			recordsList.RemoveAt(maxAmountOfBestRecords - 1);
		}

		return recordsList;
	}

	private void SetBestRecordsIntoMemory(List<float> records)
	{
		int i = 0;
		foreach(var eachRecord in records)
		{
			string keyForAccessRecord = nameOfRetrievingRecordOfRace + i.ToString();
			PlayerPrefs.SetFloat(keyForAccessRecord, eachRecord);
			i++;
		}
	}
}
