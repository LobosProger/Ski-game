using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacePanel : MonoBehaviour
{
    [SerializeField] private GameObject buttonsPanel;
    [SerializeField] private Image loadingScreenImage;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextRaceButton;
    [SerializeField] private Button quitButton;

    public static RacePanel singleton;

    private void Start()
	{
        RaceEvents.OnRaceFinished += () => ShowButtonsPanel(true);
        RaceEvents.OnRaceLoaded += () => ShowLoadingOverlayImage(false);

        retryButton.onClick.AddListener(OnClickedRetryButton);
        nextRaceButton.onClick.AddListener(OnClickedNextRaceButton);
        quitButton.onClick.AddListener(OnClickedQuitButton);
	}

    private void OnClickedRetryButton()
    {
        ShowButtonsPanel(false);
        ShowLoadingOverlayImage(true);
        RaceLevelManager.singleton.RestartCurrentLevel();
    }

    private void OnClickedNextRaceButton()
    {
		ShowButtonsPanel(false);
		ShowLoadingOverlayImage(true);
		RaceLevelManager.singleton.NextRaceLevel();
	}

    private void OnClickedQuitButton()
    {
        ShowButtonsPanel(false);
		RaceLevelManager.singleton.QuitFromGame();
	}

	private void ShowButtonsPanel(bool show)
    {
        buttonsPanel.SetActive(show);
    }

    private void ShowLoadingOverlayImage(bool show)
    {
        loadingScreenImage.enabled = show;
    }
}
