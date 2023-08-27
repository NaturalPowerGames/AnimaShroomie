using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			AnalyzeClick();
		}
	}

	private void AnalyzeClick()
	{
		Vector3 screenPosition = Input.mousePosition;
		SpawnEvents.OnShootProjectileRequested?.Invoke(screenPosition);
	}
}
