using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class SpawnEvents
{
	public static Action<int> OnEnemySpawnRequested;
	public static Action<Vector3> OnShootProjectileRequested;
}
