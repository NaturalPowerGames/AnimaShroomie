using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public EnemyData enemyData;

	private void OnEnable()
	{
		SpawnEvents.OnEnemySpawnRequested += SpawnEnemy;
	}

	private void OnDisable()
	{
		SpawnEvents.OnEnemySpawnRequested -= SpawnEnemy;
	}

	private void SpawnEnemy(int index)
	{
		Enemy targetEnemy = enemyData.Enemies[index];
		EnemyController enemy = Instantiate(targetEnemy.prefab, Vector3.zero, Quaternion.identity);
		float randomYRotation = UnityEngine.Random.Range(0, 360);
		Vector3 currentAngle = enemy.transform.localEulerAngles;
		currentAngle.y = randomYRotation;
		enemy.transform.localEulerAngles = currentAngle;
		Color randomizedColor = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
		enemy.Initialize(targetEnemy.Name, targetEnemy.Health, targetEnemy.MoveSpeed, randomizedColor);		
	}
}
