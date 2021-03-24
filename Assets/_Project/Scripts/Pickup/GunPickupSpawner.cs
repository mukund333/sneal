using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnealUltra.Assets._Project.Scripts.Player;


public class GunPickupSpawner : MonoBehaviour
{
	public float spawnRadius;
	public bool testStartSpawn;
	public bool stopSpawn;
	public float timer;
	public float SpawnStartTime;
	public float SpawnDelayTime;
	public int randomInt;
	private Transform player;
	
	
	
	public PowerGunPickup powerGunPickup;
	int powerGunPickupId;
	
	void Start()
    {
		powerGunPickupId = PoolManager.instance.GetPoolID(powerGunPickup.GetPowerUpName());
		
		player = FindObjectOfType<PlayerMovement>().transform;
		
		
		
		
     	if (testStartSpawn == true)
			StartSpawning();
			   
    }
	
	 private void StartSpawning(){
		stopSpawn = false;
		
		StartCoroutine(SpawnPowerups());
		
		StartCoroutine(Timer());	
		
	}
	
	private IEnumerator SpawnPowerups(){
		float startedTime = timer;
		
		while (!stopSpawn && timer < SpawnStartTime)
		{
			yield return 0;
		}
		
		while (!this.stopSpawn)
		{
			//randomInt = Random.Range(0,items.Length);
			//Instantiate(items[randomInt],spawnPos.position,spawnPos.rotation);
		PoolManager.instance.GetObject(powerGunPickupId,(Vector2)this.player.position + UnityEngine.Random.insideUnitCircle.normalized * spawnRadius, Quaternion.identity);

			
			yield return new WaitForSeconds(SpawnDelayTime);
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
	
	private void StopSpawning(){
		stopSpawn = true;
	}

}
