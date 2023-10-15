using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
	public Rigidbody snowBall;
	public float throwDistance;
	public int throwSpeed;
	private bool justThown = false;

	private GameObject target;

	// Start is called before the first frame update
	void Start()
	{
		target = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update()
	{
		float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

		if (SnowballPool.IsAvailableCreateSnowball())
		{
			if (distanceToTarget < throwDistance && !justThown)
			{
				SnowballPool.AddSnowballToPool();
				ThrowSnowball();
			}
		}
	}

	private void ThrowSnowball()
	{
		justThown = true;
		Rigidbody tempSnowBall = Instantiate(snowBall, transform.position, transform.rotation);
		Vector3 targetDirection = Vector3.Normalize(target.transform.position - transform.position);

		//Add a small throw angle
		targetDirection += new Vector3(0, 0.33f, 0);
		tempSnowBall.AddForce(targetDirection * throwSpeed);
		Invoke(nameof(ThrowOver), 0.1f);
	}

	void ThrowOver()
	{
		justThown = false;
	}
}
