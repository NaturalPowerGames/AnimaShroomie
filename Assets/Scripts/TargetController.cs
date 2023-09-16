using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
	private MeshRenderer meshRenderer;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

	private void OnTriggerEnter(Collider other)
	{
		OnHit();
	}

	public void OnHit()
	{
		GameplayEvents.OnSFXRequested?.Invoke(SFX.Coin);
		ChangeRendererColor(Color.red);
		StartCoroutine(ChangeBackToOriginalColor());
	}

	private IEnumerator ChangeBackToOriginalColor()
	{
		yield return new WaitForSeconds(1);
		ChangeRendererColor(Color.white);
	}

	private void ChangeRendererColor(Color color)
	{
		meshRenderer.material.color = color;
	}
}
