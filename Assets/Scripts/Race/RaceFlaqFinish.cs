using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFlaqFinish : RaceFlaq
{
	protected override void OnPassedAreaOfFlaq()
	{
		RaceController.singleton.FinishRace();
	}
}
