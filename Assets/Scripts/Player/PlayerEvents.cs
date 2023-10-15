using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void OnPlayerEventHandler();
    public static event OnPlayerEventHandler onPlayerHitAction;
    public static event OnPlayerEventHandler onPlayerBoostAction;

    public static void OnHitPlayer()
    {
        if (onPlayerHitAction != null)
        {
            onPlayerHitAction();
        }    
    }

    public static void OnBoostPlayer()
    {
        if(onPlayerBoostAction != null)
        {
            onPlayerBoostAction();
        }
    }
}
