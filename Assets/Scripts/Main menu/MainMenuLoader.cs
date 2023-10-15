using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{
    [SerializeField] private string levelLaunchSceneName;

	private void OnEnable()
	{
		MainMenuEvents.OnStartingGameEvent += LauchLevel;
		MainMenuEvents.OnQuittingFromGameEvent += QuitFromGame;
	}

	private void OnDisable()
	{
		MainMenuEvents.OnStartingGameEvent -= LauchLevel;
		MainMenuEvents.OnQuittingFromGameEvent -= QuitFromGame;
	}

	private void LauchLevel()
    {
        SceneManager.LoadScene(levelLaunchSceneName);
    }

	private void QuitFromGame()
	{
		Application.Quit();
	}
}
