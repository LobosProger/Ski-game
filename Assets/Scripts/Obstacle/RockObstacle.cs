using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacle : Obstacle
{
	protected override void OnPlayerEntered(Collision player)
	{
		Debug.Log("Player faced with rock obstacle!");
		PlayerEvents.OnHitPlayer();
	}
}
