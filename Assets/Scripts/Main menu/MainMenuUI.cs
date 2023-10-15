using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button quitFromGameButton;
	[SerializeField] private Image overlayTransitionImage;

	private void Start()
	{
		startGameButton.onClick.AddListener(OnButtonStartClicked);
		quitFromGameButton.onClick.AddListener(OnButtonQuitClicked);
	}

	private void OnButtonStartClicked()
	{
		StartCoroutine(LoadingLevelTransition());
	}

	private void OnButtonQuitClicked()
	{
		StartCoroutine(QuttingFromGameTransition());
	}

	private IEnumerator LoadingLevelTransition()
	{
		overlayTransitionImage.DOColor(new Color(1f, 1f, 1f, 1f), 0.5f);
		yield return new WaitForSeconds(1);
		MainMenuEvents.OnStartGame();
	}

	private IEnumerator QuttingFromGameTransition()
	{
		overlayTransitionImage.DOColor(new Color(0f, 0f, 0f, 1f), 0.5f);
		yield return new WaitForSeconds(1);
		MainMenuEvents.OnQuitFromGame();
	}
}
