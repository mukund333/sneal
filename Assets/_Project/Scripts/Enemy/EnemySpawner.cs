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

		public float spawnRadius = 300f;

		private bool stopSpawn;

		private Transform player;

		public bool testStartSpawn = true;

		private void Start(){
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

		private void StartSpawning(){
			stopSpawn = false;
			for (int i = 0; i < enemies.Length; i++)
			{
				StartCoroutine(SpawnEnemy(enemies[i]));
			}
			StartCoroutine(Timer());
		}

		private void StopSpawning(){
			stopSpawn = true;
		}

		private IEnumerator SpawnEnemy(EnemyInfo enemy){
			float startedTime = timer;
			float startFrequency = enemy.spawnFreqRange.x;
			float spawnFrequency = 0f;
			while (!stopSpawn && timer < enemy.spawnStartTime)
			{
				yield return 0;
			}
			while (!this.stopSpawn)
			{
				PoolManager.instance.GetObject(enemy.poolId, (Vector2)this.player.position + UnityEngine.Random.insideUnitCircle.normalized * spawnRadius, Quaternion.identity);
				spawnFrequency = Mathf.Lerp(startFrequency, enemy.spawnFreqRange.y, enemy.curve.Evaluate(Mathf.Lerp(0f, 1f, (this.timer - startedTime) / (float)enemy.timeToMaxSpawnFreq)));
				//MonoBehaviour.print(spawnFrequency);
				yield return new WaitForSeconds(1f / spawnFrequency);
			}
			yield break;
		}

		private IEnumerator Timer(){
			timer = 0f;
			while (!stopSpawn)
			{
				timer += Time.deltaTime;
				yield return 0;
			}
			timer = 0f;
			yield break;
		}
	}
}
