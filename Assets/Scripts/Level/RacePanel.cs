using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class RacePanel : MonoBehaviour
{
    [SerializeField] private GameObject buttonsPanel;
    [SerializeField] private Image loadingScreenImage;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextRaceButton;
    [SerializeField] private Button quitButton;

	private void Start()
	{
		RaceEvents.OnRaceFinished += () => ShowButtonsPanel(true);

		retryButton.onClick.AddListener(OnClickedRetryButton);
        nextRaceButton.onClick.AddListener(OnClickedNextRaceButton);
        quitButton.onClick.AddListener(OnClickedQuitButton);
	}

	private void OnDestroy()
	{
		RaceEvents.OnRaceFinished -= () => ShowButtonsPanel(true);

		retryButton.onClick.RemoveListener(OnClickedRetryButton);
		nextRaceButton.onClick.RemoveListener(OnClickedNextRaceButton);
		quitButton.onClick.RemoveListener(OnClickedQuitButton);
	}

	private void OnClickedRetryButton()
    {
        ShowButtonsPanel(false);
        RaceLevelManager.singleton.RestartCurrentLevel();
    }

    private void OnClickedNextRaceButton()
    {
		ShowButtonsPanel(false);
		RaceLevelManager.singleton.NextRaceLevel();
	}

    private void OnClickedQuitButton()
    {
        ShowButtonsPanel(false);
		RaceLevelManager.singleton.QuitFromGame();
	}

	private void ShowButtonsPanel(bool show)
     {
		// Fixed solution on time. Because on unknown reason there are two gameobjects Race panel after restarting race
		// and first - null, second - placed on scene
        if(buttonsPanel != null)
        {
			buttonsPanel.SetActive(show);
		}
    }
}
