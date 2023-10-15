using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LeaderboardCardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text recordNumberText;
    [SerializeField] private TMP_Text recordTimeText;

    public void ShowRecordOnCard(int placeOfRecord, float timeOfRecordInSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeOfRecordInSeconds);
        string formattedTime;

        if(time.Seconds < 10)
            formattedTime = time.Minutes.ToString() + ":0" + time.Seconds;
        else
			formattedTime = time.Minutes.ToString() + ":" + time.Seconds;

        recordNumberText.text = "#" + placeOfRecord.ToString();
        recordTimeText.text = formattedTime;
    }
}
