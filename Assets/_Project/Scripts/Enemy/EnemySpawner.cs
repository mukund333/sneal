using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Player;

namespace SnealUltra.Assets._Project.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
	{

		public EnemyInfo[] enemies;


		private float timer;


		private bool stopSpawn;


		private Transform player;

		public bool testStartSpawn = true;

		private void Start()
		{
			this.player = UnityEngine.Object.FindObjectOfType<PlayerMovement>().transform;
			GameMaster.instance.OnGameEnd += this.StopSpawning;
			//GameMaster.instance.OnGameStart += this.StartSpawning;


			for (int i = 0; i < enemies.Length; i++)
			{
				this.enemies[i].poolId = PoolManager.instance.GetPoolID(this.enemies[i].Name);


			}

			if (testStartSpawn == true)
				StartSpawning();

		}


		private void StartSpawning()
		{
			this.stopSpawn = false;
			for (int i = 0; i < this.enemies.Length; i++)
			{
				base.StartCoroutine(this.SpawnEnemy(this.enemies[i]));
			}
			base.StartCoroutine(this.Timer());
		}

		private void StopSpawning()
		{
			this.stopSpawn = true;
		}


		private IEnumerator SpawnEnemy(EnemyInfo enemy)
		{
			float startedTime = this.timer;
			float startFrequency = enemy.spawnFreqRange.x;
			float spawnFrequency = 0f;
			while (!this.stopSpawn && this.timer < (float)enemy.spawnStartTime)
			{
				yield return 0;
			}
			while (!this.stopSpawn)
			{
				PoolManager.instance.GetObject(enemy.poolId, (Vector2)this.player.position + UnityEngine.Random.insideUnitCircle.normalized * 300f, Quaternion.identity);
				spawnFrequency = Mathf.Lerp(startFrequency, enemy.spawnFreqRange.y, enemy.curve.Evaluate(Mathf.Lerp(0f, 1f, (this.timer - startedTime) / (float)enemy.timeToMaxSpawnFreq)));
				MonoBehaviour.print(spawnFrequency);
				yield return new WaitForSeconds(1f / spawnFrequency);
			}
			yield break;
		}


		private IEnumerator Timer()
		{
			this.timer = 0f;
			while (!this.stopSpawn)
			{
				this.timer += Time.deltaTime;
				yield return 0;
			}
			this.timer = 0f;
			yield break;
		}

	}
}
