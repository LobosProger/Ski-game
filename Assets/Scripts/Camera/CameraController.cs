using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private float intensityShake;
	[SerializeField] private float timeOfShaking;
    private CinemachineVirtualCamera cinemachineVirtualCamera;

	private void Start()
	{
		cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
	}

	private void OnEnable()
	{
		PlayerEvents.onPlayerHitAction += ShakeCamera;
	}

	private void OnDisable()
	{
		PlayerEvents.onPlayerHitAction -= ShakeCamera;
	}

	private void ShakeCamera()
	{
		StartCoroutine(ShakingCamera());
	}

	private IEnumerator ShakingCamera()
	{
		cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 2;
		yield return new WaitForSeconds(timeOfShaking);
		cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
	}
}
