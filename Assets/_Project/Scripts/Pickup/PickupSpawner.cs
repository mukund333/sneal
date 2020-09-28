using SnealUltra.Assets._Project.Scripts.Pickup;
using SnealUltra.Assets._Project.Scripts.Player;
using System.Collections;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{


	public float spawnRadius;
	private float timer;
	private bool stopSpawn;
	private Transform player;
	public bool testStartSpawn = true;

	int poolId;

	
	public InvincibilityPickup invincibilityPickup;

	private void Awake()
	{
		poolId = PoolManager.instance.GetPoolID(invincibilityPickup.GetPowerUpName());
		invincibilityPickup.SetPowerUpPoolId(poolId);
	}

	private void Start()
	{
        #region caching referance
        player = FindObjectOfType<PlayerMovement>().transform;
		
        #endregion

        #region events
        GameMaster.instance.OnGameEnd += this.StopSpawning;
		//GameMaster.instance.OnGameStart += this.StartSpawning;
		#endregion	
		
		
		

		if (testStartSpawn == true)
			StartSpawning();



	}

	private void StartSpawning()
	{
		stopSpawn = false;
		
		StartCoroutine(SpawnPowerups(invincibilityPickup));
		
		StartCoroutine(Timer());
	}


	private void StopSpawning()
	{
		stopSpawn = true;
	}

	private IEnumerator SpawnPowerups(InvincibilityPickup powerup)
	{
		
		float startedTime = timer;
		float startFrequency = powerup.GetSpawnFreqRange().x;
		float spawnFrequency = 0f;
		while (!stopSpawn && timer < powerup.GetSpawnStartTime())
		{
			yield return 0;
		}
		while (!this.stopSpawn)
		{
			PoolManager.instance.GetObject(powerup.GetPoolId(), (Vector2)this.player.position + UnityEngine.Random.insideUnitCircle.normalized * spawnRadius, Quaternion.identity);
			spawnFrequency = Mathf.Lerp(startFrequency, powerup.GetSpawnFreqRange().y, powerup.GetCurve().Evaluate(Mathf.Lerp(0f, 1f, (this.timer - startedTime) / (float)powerup.GetMaxFreq())));
			MonoBehaviour.print(spawnFrequency);
			yield return new WaitForSeconds(1f / spawnFrequency);
		}
		yield break;
	}

	private IEnumerator Timer()
	{
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


