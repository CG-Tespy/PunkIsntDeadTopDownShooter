﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Spawns enemy waves one after another, be it after a timer or after a wave dies.
/// </summary>
public class EnemyWaveSequencer : MonoBehaviour 
{
	public UnityEvent AllWavesDead  							{ get; protected set; }
	[SerializeField] EnemyWave[] waves;
	[SerializeField] bool continueOnWaveDeath;
	[SerializeField] float spawnInterval = 						3;
	[SerializeField] float firstSpawnDelay = 					3;
	int waveIndex = 											0;

	// Use this for initializing own members
	void Awake () 
	{
		if (waves.Length == 0)
			throw new System.MissingFieldException(this.name + " needs waves to spawn.");

		AllWavesDead = 											new UnityEvent();
		
	}
	
	// Often used for accessing things initialized already, like stuff in Awake
	void Start () 
	{
		DeactivateAllWaves();
		
		Invoke("SpawnNextWave", firstSpawnDelay);

		if (continueOnWaveDeath)
			SpawnWavesAfterClear();
		else 
			SpawnWaves();	
	}

	void SpawnNextWave()
	{
		if (waveIndex == waves.Length) // At this point, all the waves are dead, so...
		{
			AllWavesDead.Invoke();
			return;
		}
			
		waves[waveIndex].Activate();
		waveIndex++;
	}

	void DeactivateAllWaves()
	{
		foreach (EnemyWave wave in waves)
			if (wave.gameObject.activeSelf)
				wave.Deactivate();

		waveIndex = 						0;
	}

	void SpawnWavesAfterClear()
	{
		for (int i = 0; i < waves.Length; i++)
			waves[i].AllEnemiesDead.AddListener( () => Invoke("SpawnNextWave", spawnInterval));
		
	}

	/// <summary>
	/// Spawns waves spaced by the time interval, regardless of whether they've already been 
	/// cleared or not.
	/// </summary>
	void SpawnWaves()
	{
		for (int i = 1; i < waves.Length; i++)
		{
			if (i == 1)
				Invoke("SpawnNextWave", firstSpawnDelay + spawnInterval);
			else 
				Invoke("SpawnNextWave", spawnInterval * (i + 1));	
		}
	}
	
}
