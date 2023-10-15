using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFlaqStart : RaceFlaq
{
	protected override void OnPassedAreaOfFlaq()
	{
		GetComponent<AudioSource>().Play();
		RaceController.singleton.StartRace();
	}
}
