using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleController : MonoBehaviour
{
    [SerializeField] private float forceOfKnockingBack;
    [SerializeField] private float amountOfTimeRecovery;
	public bool isPlayerKnockingBack { get; private set; }

	private Rigidbody rb;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnEnable()
	{
		PlayerEvents.onPlayerHitAction += HitWithObstacle;
	}

	private void OnDisable()
	{
		PlayerEvents.onPlayerHitAction -= HitWithObstacle;
	}

	private void HitWithObstacle()
	{
		StartCoroutine(KnockingBackPlayer());
	}

	private IEnumerator KnockingBackPlayer()
	{
		Vector3 force = (-rb.transform.forward) * forceOfKnockingBack;
		rb.AddForce(force, ForceMode.Impulse);
		isPlayerKnockingBack = true;
		yield return new WaitForSeconds(amountOfTimeRecovery);
		isPlayerKnockingBack = false;
	}
}
