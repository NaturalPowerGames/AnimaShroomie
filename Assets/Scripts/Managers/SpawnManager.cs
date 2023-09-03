using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public EnemyData enemyData;
	public ProjectileController projectilePrefab;
	public SphereCollider enemySpawnArea;
	public Transform[] PatrolRoutes;

	private void OnEnable()
	{
		SpawnEvents.OnEnemySpawnRequested += SpawnSimpleEnemy;
		SpawnEvents.OnPatrollingEnemyRequested += SpawnPatrolEnemy;
		SpawnEvents.OnShootProjectileRequested += OnShootProjectileRequested;
	}

	private void SpawnPatrolEnemy(int index, int patrolRoute)
	{
		EnemyController enemy = SpawnEnemy(0);
		enemy.AssignPatrolRoute(PatrolRoutes[patrolRoute]);
	}

	private void OnDisable()
	{
		SpawnEvents.OnEnemySpawnRequested -= SpawnSimpleEnemy;
		SpawnEvents.OnShootProjectileRequested -= OnShootProjectileRequested;
	}

	private void SpawnSimpleEnemy(int index)
	{
		SpawnEnemy(index);
	}

	private EnemyController SpawnEnemy(int index)
	{
		Enemy targetEnemy = enemyData.Enemies[index];
		EnemyController enemy = Instantiate(targetEnemy.prefab, Vector3.zero, Quaternion.identity);
		float randomYRotation = UnityEngine.Random.Range(0, 360);
		Vector3 currentAngle = enemy.transform.localEulerAngles;
		currentAngle.y = randomYRotation;
		enemy.transform.localEulerAngles = currentAngle;
		Color randomizedColor = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
		enemy.Initialize(targetEnemy.Name, targetEnemy.Health, targetEnemy.MoveSpeed, randomizedColor);
		float randomX = UnityEngine.Random.Range(enemySpawnArea.bounds.min.x, enemySpawnArea.bounds.max.x);
		float randomZ = UnityEngine.Random.Range(enemySpawnArea.bounds.min.z, enemySpawnArea.bounds.max.z);
		enemy.transform.position = new Vector3(randomX, 0f, randomZ);
		return enemy;		
	}

	private void OnShootProjectileRequested(Vector3 screenPosition)
	{
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		ProjectileController projectile = Instantiate(projectilePrefab, ray.origin, Quaternion.identity);
		projectile.Initialize(projectilePrefab.transform.eulerAngles, ray.direction);
	}
}
