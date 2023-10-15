using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SnowballPool
{
    private const int maxAmountSnowballs = 30;
    private static int createdSnowballs = 0;

    public static bool IsAvailableCreateSnowball() => createdSnowballs < maxAmountSnowballs;

    public static void AddSnowballToPool() => createdSnowballs++;

    public static void RemoveSnowballFromPool() => createdSnowballs--;
}
