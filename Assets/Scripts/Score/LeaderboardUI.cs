using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
	[SerializeField] private GameObject panelOfCards;
    [SerializeField] private LeaderboardCardUI scoreCard;

    public static LeaderboardUI singleton;

	private void Start()
	{
		singleton = this;
	}

	public void ShowRecordsOnUI(List<float> recordsList)
    {
		for(int i=0; i<recordsList.Count; i++)
		{
			int placeOfRecord = i + 1;
			LeaderboardCardUI instantiatedScoreCard = Instantiate(scoreCard, panelOfCards.transform);
			instantiatedScoreCard.ShowRecordOnCard(placeOfRecord, recordsList[i]);
		}
    }
}
