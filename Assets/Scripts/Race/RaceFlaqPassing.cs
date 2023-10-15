using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFlaqPassing : RaceFlaq
{
	[SerializeField] private AudioClip soundOfPassingFlaq;
	[SerializeField] private AudioClip soundOfMissingFlaq;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void OnPassingRoute()
	{
		if (isAreaOfFlaqPassed)
			return;

		audioSource.clip = soundOfPassingFlaq;
		audioSource.Play();
		RaceController.singleton.OnPassedFlaq();
	}

	public void OnMissedFlaqRoute()
	{
		if (isAreaOfFlaqPassed)
			return;

		audioSource.clip = soundOfMissingFlaq;
		audioSource.Play();
		RaceController.singleton.OnMissedFlaq();
	}
}
