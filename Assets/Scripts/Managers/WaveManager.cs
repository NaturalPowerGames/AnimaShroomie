using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
	public Wave[] waves;
	public int[] ints;
	private int enemiesSpawned, currentWave;
	private bool waveFinishedSpawning;
	private void Start()
	{
		StartWave(0);
	}

	private void OnEnable()
	{
		//SpawnEvents.OnEnemySpawned += OnEnemySpawned;
	}

	private void OnEnemySpawned()
	{
		enemiesSpawned++;
	}

	private void OnEnemyDeath()
	{
		enemiesSpawned--;
		if(enemiesSpawned == 0 && waveFinishedSpawning)
		{
			StartWave(currentWave + 1);
		}
	}

	private void OnDisable()
	{
		//in the enemies, send the message that it was killed
	}

	private IEnumerator StartWave(int waveIndex)
	{
		currentWave = waveIndex; 
		waveFinishedSpawning = false;
		Wave wave = waves[currentWave];
		for (int i = 0; i < wave.EnemiesInWave.Length; i++)
		{
			//tell the enemy or spawn manager to spawn an enemy
			//SpawnEvents.OnSpawnEnemyRequested?.Invoke(wave.EnemiesInWave[i]);
			yield return new WaitForSeconds(wave.timeBetweenEnemies);
		}
		waveFinishedSpawning = true;
	}
}
