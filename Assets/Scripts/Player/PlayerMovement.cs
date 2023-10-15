using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Transform groundCheckObject;
	[SerializeField] private LayerMask groundLayers;
	[Space]
	[SerializeField] private float rotatingSpeed = 1f;
	[SerializeField] private float movingSpeed = 1f;
	[SerializeField] private float boostingMultiplierSpeed = 1.5f;
	[Space]
	[SerializeField] private KeyCode turnLeftKeycode;
	[SerializeField] private KeyCode turnRightKeycode;
	[SerializeField] private KeyCode boostingKeycode;

	private PlayerObstacleController obstacleController;
	private Rigidbody rb;
	private Animator animator;

	private float velocityDurationWithRotation;
	private bool isPlayerOnGround;
	private bool isPlayerBoosting;
	private bool isPlayerPassedBoostingFlaq;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		obstacleController = GetComponent<PlayerObstacleController>();
	}

	private void OnEnable()
	{
		PlayerEvents.onPlayerBoostAction += BoostPlayerByFlaqOnTime;
	}

	private void OnDisable()
	{
		PlayerEvents.onPlayerBoostAction -= BoostPlayerByFlaqOnTime;
	}

	private void Update()
	{
		if (!obstacleController.isPlayerKnockingBack)
		{
			if (Input.GetKey(turnLeftKeycode) && isPlayerOnGround)
			{
				TurnLeft();
			}

			if (Input.GetKey(turnRightKeycode) && isPlayerOnGround)
			{
				TurnRight();
			}

			if (Input.GetKey(boostingKeycode) || isPlayerPassedBoostingFlaq)
			{
				isPlayerBoosting = true;
			}
			else
			{
				isPlayerBoosting = false;
			}
		}

		ClampingRotation();

		if (transform.rotation.eulerAngles.y < 180)
		{
			velocityDurationWithRotation = Mathf.InverseLerp(90, 180, transform.rotation.eulerAngles.y);
		}
		else
		{
			velocityDurationWithRotation = Mathf.InverseLerp(270, 180, transform.rotation.eulerAngles.y);
		}

		SettingAnimatorParameters();
		CheckIfPlayerOnGround();
	}

	private void FixedUpdate()
	{
		if (!obstacleController.isPlayerKnockingBack)
		{
			Vector3 force;
			if (isPlayerBoosting)
			{
				force = transform.forward * movingSpeed * boostingMultiplierSpeed;
			}
			else
			{
				force = transform.forward * movingSpeed * velocityDurationWithRotation;
			}

			force.y = rb.velocity.y;
			rb.velocity = force;
		}
	}

	private void SettingAnimatorParameters()
	{
		animator.SetFloat("playerSpeed", velocityDurationWithRotation);
		animator.SetBool("grounded", isPlayerOnGround);
	}

	private void TurnRight()
	{
		transform.Rotate(new Vector3(0, -rotatingSpeed, 0) * Time.deltaTime, Space.Self);
	}

	private void TurnLeft()
	{
		transform.Rotate(new Vector3(0, rotatingSpeed, 0) * Time.deltaTime, Space.Self);
	}

	private void ClampingRotation()
	{
		// Perform calculations to clamp rotation to 90 degree
		Vector3 clampedRotation = transform.eulerAngles;
		// Initial rotation of player on the track - 180 degree
		clampedRotation.y = Mathf.Clamp(clampedRotation.y, 90f, 270f);
		transform.eulerAngles = clampedRotation;
	}

	private void BoostPlayerByFlaqOnTime()
	{
		StartCoroutine(BoostingPlayerByFlaqOnTime());
	}

	private IEnumerator BoostingPlayerByFlaqOnTime()
	{
		isPlayerPassedBoostingFlaq = true;
		yield return new WaitForSeconds(1.5f);
		isPlayerPassedBoostingFlaq = false;
	}

	private void CheckIfPlayerOnGround() => isPlayerOnGround = Physics.Linecast(transform.position, groundCheckObject.transform.position, groundLayers);
}
