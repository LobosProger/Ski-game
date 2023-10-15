using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFlaqCollider : MonoBehaviour
{
    [SerializeField] private RaceFlaqPassing raceFlaqController;
	[SerializeField] private CheckTypeOfCollider checkTypeOfCollider;

	private enum CheckTypeOfCollider { passingRoute, missingFlaq }

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			switch(checkTypeOfCollider)
			{
				case CheckTypeOfCollider.passingRoute: raceFlaqController.OnPassingRoute(); break;
				case CheckTypeOfCollider.missingFlaq: raceFlaqController.OnMissedFlaqRoute(); break;
			}
		}
	}
}
