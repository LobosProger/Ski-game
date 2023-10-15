using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			OnPlayerEntered(collision);
		}
	}

	protected abstract void OnPlayerEntered(Collision player);
}
