using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float health, movespeed;
	private MeshRenderer meshRenderer;
	public Transform[] waypoints;
	public Vector3[] waypointLocations;
	private int targetLocation = 0;
	public float arrivalDistance;
	private bool moving;

	private void GetWaypointPositions()
	{
		waypointLocations = new Vector3[waypoints.Length];
		for (int i = 0; i < waypointLocations.Length; i++)
		{
			waypointLocations[i] = waypoints[i].transform.position;
		}
	}

	private void StartGoingToLocation(int index)
	{
		targetLocation = index;
		moving = true;
	}

	private void Update()
	{
		if (waypointLocations == null || !moving) return;
		transform.position = Vector3.MoveTowards(transform.position, waypointLocations[targetLocation], movespeed);
		CheckIfAtTargetLocation();
	}

	internal void AssignPatrolRoute(Transform patrolRouteParent)
	{
		waypoints = new Transform[patrolRouteParent.childCount];
		for (int i = 0; i < waypoints.Length; i++)
		{
			waypoints[i] = patrolRouteParent.GetChild(i);
		}
		transform.position = waypoints[0].position;
		GetWaypointPositions();
	}

	private void CheckIfAtTargetLocation()
	{
		float distance = Vector3.Distance(transform.position, waypointLocations[targetLocation]);
		if (distance < arrivalDistance)
		{
			StartGoingToLocation(NextLocation());
		}
	}

	public void Initialize(string name, float health, float movespeed, Color color)
	{
		GetWaypointPositions();
		StartGoingToLocation(0);
		this.name = name;
		this.health = health;
		this.movespeed = movespeed;
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material.color = color;
	}

	private int NextLocation()
	{
		targetLocation++;
		if (waypointLocations.Length <= targetLocation)
		{
			targetLocation = 0;
		}
		return targetLocation;
	}

	private void ChangeHealth(float change)
	{
		health += change;
		if(health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		meshRenderer.material.color = Color.black;
		moving = false;
		GameplayEvents.OnEnemyKilled?.Invoke(name);
		string announcement = $"Enemy {name} has been killed";
		UIEvents.OnAnnouncementRequested?.Invoke(announcement, 3);
	}

	private void OnCollisionEnter(Collision collision)
	{
		//checking for damage
		CheckForDamageDealer(collision);
		//knockback
		CheckForKnockback(collision);
	}

	private void CheckForDamageDealer(Collision collision)
	{
		IDealsDamageToEnemies damageDealer = collision.gameObject.GetComponent<IDealsDamageToEnemies>();
		if (damageDealer != null)
		{
			ChangeHealth(-damageDealer.Damage());
		}
	}

	private void CheckForKnockback(Collision collision)
	{
		IKnockback knockbacker = collision.gameObject.GetComponent<IKnockback>();
		if (knockbacker != null)
		{
			//rigidbody.AddForce(knockbacker.KnockbackForce());
		}
	}
}
