using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanObstacle : Obstacle
{
    protected override void OnPlayerEntered(Collision playerCollision)
    {
        Debug.Log("Player faced with snowman!");
        PlayerEvents.OnHitPlayer();
        Destroy(gameObject);
    }
}
