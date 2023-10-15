using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceEvents : MonoBehaviour
{
    public delegate void RaceEventHandler();
	public static event RaceEventHandler OnRaceStarted;
	public static event RaceEventHandler OnRaceFinished;
    public static event RaceEventHandler OnRaceLoaded;

    public static void OnStartRace()
    {
        OnRaceStarted();
  	}   

    public static void OnFinishRace()
    {
        OnRaceFinished();
        Debug.Log("Finishing race!!!");
    }

	private void OnLevelWasLoaded(int level)
	{
        Debug.Log("Load level!");
        OnRaceLoaded();
	}
}
