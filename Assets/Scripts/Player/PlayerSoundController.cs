using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip soundOfCollisionWithObstacle;
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnEnable()
	{
		PlayerEvents.onPlayerHitAction += PlaySoundOfHit;
	}

	private void OnDisable()
	{
		PlayerEvents.onPlayerHitAction -= PlaySoundOfHit;
	}

	public void PlaySoundOfHit()
	{
		audioSource.clip = soundOfCollisionWithObstacle;
		audioSource.Play();
	}
}
