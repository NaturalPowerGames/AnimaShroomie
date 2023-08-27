using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health, movespeed;
	private MeshRenderer meshRenderer;

	private void Update()
	{
		transform.position += transform.forward * movespeed;
	}

	public void Initialize(string name, float health, float movespeed, Color color)
	{
		this.name = name;
		this.health = health;
		this.movespeed = movespeed;
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material.color = color;
	}
}
