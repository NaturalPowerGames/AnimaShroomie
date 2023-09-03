using UnityEngine;
using System;

public static class SpawnEvents
{
	public static Action<int> OnEnemySpawnRequested;
	/// <summary>
	/// Enemy Index , Patrol Route index
	/// </summary>
	public static Action<int,int> OnPatrollingEnemyRequested;
	public static Action<Vector3> OnShootProjectileRequested;
}
