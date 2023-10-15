using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFlaq : MonoBehaviour
{
	protected bool isAreaOfFlaqPassed;

	private void OnTriggerEnter(Collider other)
	{
		if (isAreaOfFlaqPassed)
			return;

		if(other.gameObject.CompareTag("Player"))
		{
			isAreaOfFlaqPassed = true;
			OnPassedAreaOfFlaq();
		}
	}

	protected virtual void OnPassedAreaOfFlaq()
	{

	}
}
