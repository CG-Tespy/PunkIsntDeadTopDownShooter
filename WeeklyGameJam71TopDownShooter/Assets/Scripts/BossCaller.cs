using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BossCaller : MonoBehaviour 
{
	public enum CallCondition 
	{
		onWaveDeath, onWaveSequenceDeath, onEnemyDeath
	}

	public CallCondition spawnOn;
	[SerializeField] EnemyController bossToCall;
	
	[SerializeField] EnemyWave waveToWatch;
	[SerializeField] EnemyWaveSequencer sequenceToWatch;
	[SerializeField] EnemyController enemyToWatch;

	// Often used for accessing things initialized already, like stuff in Awake
	void Start () 
	{
		SetupWatch();
	}

	void SetupWatch()
	{
		switch (spawnOn)
		{
			case CallCondition.onEnemyDeath:
				enemyToWatch.Died.AddListener(SpawnBoss);
				break;
			case CallCondition.onWaveDeath:
				waveToWatch.AllEnemiesDead.AddListener(SpawnBoss);
				break;
			case CallCondition.onWaveSequenceDeath:
				sequenceToWatch.AllWavesDead.AddListener(SpawnBoss);
				break;
			default:
				throw new System.ArgumentException("Must account for call condition " + spawnOn);
		}
	}

	void SpawnBoss()
	{
		bossToCall.gameObject.SetActive(true);
	}
}
