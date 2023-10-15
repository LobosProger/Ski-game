using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

	private void Update()
	{
		//transform.LookAt(target);
		transform.Translate(transform.right * speed * Time.deltaTime);
	}
}
