using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanShootingController : MonoBehaviour
{
	public int rayCount = 7;
	public float angleSpread = 30;
	public float rayDistance = 15;


	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ShootHitscan();
		}
	}

	public void ShootHitscan()
	{
		RaycastHit hit;

		// Calculate the angle between each ray
		float angleStep = angleSpread / (rayCount - 1);

		// Get the forward direction of the transform
		Vector3 forward = -transform.right;

		// Iterate through each ray
		for (int i = 0; i < rayCount; i++)
		{
			// Calculate the current angle for the ray
			float angle = -angleSpread / 2 + i * angleStep;

			// Calculate the direction vector for the ray
			Vector3 direction = Quaternion.Euler(0, angle, 0) * forward;
			if (Physics.Raycast(transform.position, direction, out hit, rayDistance)) // the first part of the raycast is the origin, second is the direction, Camera.main is for shooting
			{
				if (hit.collider.GetComponent<TargetController>())
				{
					hit.collider.GetComponent<TargetController>().OnHit();
				}
			}
		}
		Debug.Log("Hitting");
	}

	private void OnDrawGizmos()
	{
		//Gizmos.color = Color.red;
		//Gizmos.DrawLine(Camera.main.transform.position, Camera.main.transform.forward * 25);

		// Calculate the angle between each ray
		float angleStep = angleSpread / (rayCount - 1);

		// Get the forward direction of the transform
		Vector3 forward = -transform.right;

		// Iterate through each ray
		for (int i = 0; i < rayCount; i++)
		{
			// Calculate the current angle for the ray
			float angle = -angleSpread / 2 + i * angleStep;

			// Calculate the direction vector for the ray
			Vector3 direction = Quaternion.Euler(0, angle, 0) * forward;

			// Draw the ray
			Gizmos.color = Color.red;
			Gizmos.DrawRay(transform.position, direction * rayDistance);
		}
	}
}
