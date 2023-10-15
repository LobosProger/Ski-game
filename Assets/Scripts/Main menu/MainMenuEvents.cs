using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    public delegate void MainMenuHandler();
    public static event MainMenuHandler OnStartingGameEvent;
    public static event MainMenuHandler OnQuittingFromGameEvent;

    public static void OnStartGame()
    {
        if(OnStartingGameEvent != null)
        {
            OnStartingGameEvent();
        }
    }

    public static void OnQuitFromGame()
    {
        if(OnQuittingFromGameEvent != null)
        {
            OnQuittingFromGameEvent();
        }
    }
}
