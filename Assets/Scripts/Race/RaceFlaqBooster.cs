using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFlaqBooster : RaceFlaq
{
    private AudioSource soundOfBoost;

	private void Start()
	{
		soundOfBoost = GetComponent<AudioSource>();
	}

	protected override void OnPassedAreaOfFlaq()
	{
		soundOfBoost.Play();
		PlayerEvents.OnBoostPlayer();
	}
}
