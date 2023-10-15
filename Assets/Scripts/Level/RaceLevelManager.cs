using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceLevelManager : MonoBehaviour
{
	[SerializeField] private string defaultLevelName;
	[SerializeField] private int maxAmountOfCreatedLevels;

	public static RaceLevelManager singleton;
	public string nameOfCurrentLevel => defaultLevelName + currentLevel.ToString();

	private int currentLevel = 1;

	private void Start()
	{
		if(singleton != null)
		{
			Destroy(gameObject);
			return;
		}

		singleton = this;
		DontDestroyOnLoad(gameObject);
	}

	public void RestartCurrentLevel()
	{
		string nameOfLoadingLevel = defaultLevelName + currentLevel.ToString();
		SceneManager.LoadSceneAsync(nameOfLoadingLevel);
	}

	public void NextRaceLevel()
	{
		currentLevel++;
		if(currentLevel > maxAmountOfCreatedLevels)
		{
			currentLevel = 1;
		}

		string nameOfLoadingLevel = defaultLevelName + currentLevel.ToString();
		SceneManager.LoadSceneAsync(nameOfLoadingLevel);
	}

	public void QuitFromGame()
	{
		Application.Quit();
	}
}
